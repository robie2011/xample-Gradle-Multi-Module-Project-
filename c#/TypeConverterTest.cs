using System;
using System.ComponentModel;
using System.Globalization;
using Xunit;

// Doc: https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.typeconverter?view=net-5.0
namespace Messerli.NakaOne.App.Shared.Test
{
    public sealed class TypeConverterTest
    {
        [Fact]
        public void CanConvert()
        {
            var value = (Hello)TypeDescriptor
                .GetConverter(typeof(Hello))
                .ConvertFrom("23")!;

            Assert.Equal(23, value.Number);
        }

        [TypeConverter(typeof(HelloTypeConverter))]
        internal class Hello
        {
            public Hello(int number)
            {
                Number = number;
            }

            private Hello()
            {
                Number = -1;
            }

            public int Number { get; }
        }

        internal class HelloTypeConverter : TypeConverter
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
                    return new Hello(int.Parse(strValue));
                }

                return base.ConvertFrom(context, culture, value);
            }
        }
    }
}
