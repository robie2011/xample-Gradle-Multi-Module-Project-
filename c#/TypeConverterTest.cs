using System;
using System.ComponentModel;
using System.Globalization;
using Xunit;

// Doc: https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.typeconverter?view=net-5.0
namespace Examples
{
    public sealed class TypeConverterTest
    {
        [Fact]
        public void Convert()
        {
            // No attribute assigned. This returns default converter
            var converter0 = TypeDescriptor.GetConverter(typeof(TypeWithoutAttribute));
            Assert.Equal(typeof(TypeConverter), converter0.GetType());

            // Adding attribute programmatically
            TypeDescriptor.AddAttributes(
                typeof(TypeWithoutAttribute),
                new TypeConverterAttribute(typeof(StringToIntTypeConverter)));

            // Should return assigned converter
            var converter1 = TypeDescriptor.GetConverter(typeof(TypeWithoutAttribute));
            Assert.Equal(typeof(StringToIntTypeConverter), converter1.GetType());
            
            // Should convert correctly
            var value = (TypeWithoutAttribute)converter1.ConvertFrom("23")!;
            Assert.Equal(23, value.Number);
        }

        internal class TypeWithoutAttribute
        {
            public TypeWithoutAttribute(int number)
            {
                Number = number;
            }

            private TypeWithoutAttribute()
            {
                Number = -1;
            }

            public int Number { get; }
        }

        internal class StringToIntTypeConverter : TypeConverter
        {
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                if (typeof(string) == sourceType)
                {
                    return true;
                }

                return base.CanConvertFrom(context, sourceType);
            }

            public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
            {
                if (value is string strValue && !string.IsNullOrWhiteSpace(strValue))
                {
                    return new TypeWithoutAttribute(int.Parse(strValue));
                }

                return base.ConvertFrom(context, culture, value);
            }
        }
    }
}
