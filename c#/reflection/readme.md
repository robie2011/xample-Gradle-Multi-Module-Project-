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
