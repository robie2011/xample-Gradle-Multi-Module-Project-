Given:

```csharp
public sealed class TreeDb
{
    public ITable<Tree> Trees { get; private set; }
    public ITable<Leaf> Leaves { get; private set; }
}

public interface ITable<T>
    where T : class
{
    void Add(T entity);

    void AddRange(IEnumerable<T> entities);

    void Remove(T entity);

    void RemoveRange(IEnumerable<T> entities);

    IQueryable<T> GetQueryable();
}

public sealed class Table<T> : ITable<T>
    where T : class
{
    private readonly DbContext _context;

    public Table(DbContext context) => _context = context;

    public void Add(T entity) => _context.Add(entity);

    public void AddRange(IEnumerable<T> entities) => _context.AddRange(entities);

    public void Remove(T entity) => _context.Remove(entity);

    public void RemoveRange(IEnumerable<T> entities) => _context.RemoveRange(entities);

    public IQueryable<T> GetQueryable() => _context.Set<T>().AsQueryable();
}
```

```csharp
var context = Mock.Of<DbContext>();
var selectedDbType = typeof(TreeDb);
var db = (TreeDb)Activator.CreateInstance(selectedDbType, nonPublic: true)!;
foreach (var propertyInfo in selectedDbType.GetProperties())
{
    // todo: ensure property has setter
    var propertyType = propertyInfo.PropertyType!;
    if (propertyType.IsConstructedGenericType && propertyType.GetGenericTypeDefinition() == typeof(ITable<>))
    {
        var genericArgument = propertyType.GetGenericArguments()[0];
        var tableType = typeof(Table<>).MakeGenericType(genericArgument);
        propertyInfo.SetValue(db, Activator.CreateInstance(type: tableType, args: context));
    }
}
```


# Extract value from property assignment

```csharp
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using System.Reflection;

namespace Core;

internal static class PropertyAssignmentExpressionParser
{
    public static IEnumerable<KeyValuePair<string, string?>> Parse(BinaryExpression expression)
    {
        if (expression.NodeType == ExpressionType.Equal)
        {
            return new[] { GetKeyValue(expression) };
        }

        if (expression.NodeType == ExpressionType.AndAlso)
        {
            return Parse((BinaryExpression)expression.Left)
                .Concat(Parse((BinaryExpression)expression.Right));
        }

        throw new NotSupportedException(expression.NodeType.ToString());
    }

    private static KeyValuePair<string, string?> GetKeyValue(BinaryExpression expression)
    {
        var key = GetMemberName((MemberExpression)expression.Left);
        var value = expression.Right switch
        {
            ConstantExpression c => c.Value?.ToString(),
            MemberExpression { Expression: ConstantExpression cex } m => GetValueFromClosure(m, cex),
        };

        return KeyValuePair.Create(key, value);
    }

    private static string? GetValueFromClosure(MemberExpression mex, ConstantExpression cex)
    {
        var propertyName = mex.Member.Name;
        var typeField = cex.Value?.GetType().GetField(propertyName);
        var getTypeProperty = () => cex.Value?.GetType().GetProperty(propertyName);
        var value = typeField?.GetValue(cex.Value)?.ToString() ?? getTypeProperty()?.GetValue(cex.Value)?.ToString();
        return value;
    }

    private static string GetMemberName(MemberExpression ex)
        => ex.Member.GetCustomAttribute<ColumnAttribute>()!.Name!;
}
```

# Get value from property selector

```csharp
internal static class PropertyValueSelector
{
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "id is not an hungarian notation")]
    public static string CreateBackupSqlStatement<T>(this T obj, Expression<Func<T, object>> idSelector, params Expression<Func<T, object>>[] valueSelectors)
    {
        if (valueSelectors.None())
        {
            throw new ArgumentException("value selection is mandatory");
        }

        var tableName = obj!.GetType().GetCustomAttribute<TableAttribute>()!.Name;
        var idKeyValue = GetKeyValue(obj, idSelector);
        var fields = valueSelectors
            .Select(v => GetKeyValue(obj, v))
            .ToImmutableList();
        var fieldSqlStatement = string.Join(", ", fields.Select(kv => $"{kv.ColumnName}='{kv.Value}'"));

        return $"UPDATE {tableName} SET {fieldSqlStatement} WHERE {idKeyValue.ColumnName}='{idKeyValue.Value}'";
    }

    private static (string ColumnName, string? Value) GetKeyValue<T>(T obj, Expression<Func<T, object>> selector)
    {
        if (selector.Body is UnaryExpression { Operand: MemberExpression } unaryExpression)
        {
            var memberInfo = ((MemberExpression)unaryExpression.Operand).Member;
            var propertyInfo = (PropertyInfo)memberInfo;
            var columnName = propertyInfo.GetCustomAttribute<ColumnAttribute>()!.Name!;
            var value = propertyInfo.GetValue(obj)?.ToString();
            return (columnName, value);
        }

        throw new ArgumentException(selector.Body.Type.ToString());
    }
}
```
