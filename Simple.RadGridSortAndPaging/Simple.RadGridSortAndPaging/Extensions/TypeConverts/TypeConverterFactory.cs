using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.RadGridSortAndPaging.Extensions.TypeConverter;

namespace Simple.RadGridSortAndPaging.Extensions
{
    public class TypeConverterFactory
    {
        private static Dictionary<Type, ITypeConverter> s_Container;

        public static ITypeConverter GetConvertType(Type T)
        {
            if (s_Container == null)
            {
                s_Container = new Dictionary<Type, ITypeConverter>();
            }

            var sourceType = T;
            if (s_Container.ContainsKey(sourceType))
            {
                return s_Container[sourceType];
            }

            if (sourceType.IsEnum)
            {
                s_Container.Add(sourceType, new EnumConverter());
                return s_Container[sourceType];
            }

            if (sourceType == typeof(int))
            {
                s_Container.Add(sourceType, new IntegerConverter());
            }
            else if (sourceType == typeof(long))
            {
                s_Container.Add(sourceType, new LongConverter());
            }
            else if (sourceType == typeof(short))
            {

                s_Container.Add(sourceType, new ShortConverter());
            }
            else if (sourceType == typeof(float))
            {
                s_Container.Add(sourceType, new FloatConverter());
            }
            else if (sourceType == typeof(double))
            {
                s_Container.Add(sourceType, new DoubleConverter());
            }
            else if (sourceType == typeof(decimal))
            {
                s_Container.Add(sourceType, new DecimalConverter());
            }
            else if (sourceType == typeof(bool))
            {
                s_Container.Add(sourceType, new BooleanConverter());
            }
            else if (sourceType == typeof(char))
            {
                s_Container.Add(sourceType, new CharConverter());
            }
            else if (sourceType == typeof(string))
            {
                s_Container.Add(sourceType, new StringConverter());
            }
            else if (sourceType == typeof(Guid))
            {
                s_Container.Add(sourceType, new GuidConverter());
            }
            else if (sourceType == typeof(DateTime))
            {
                s_Container.Add(sourceType, new DateTimeConverter());
            }
            else
            {
                return null;
            }
            return s_Container[sourceType];
        }
        public static ITypeConverter GetConvertType<T>()
        {
            var result = GetConvertType(typeof(T));
            return result;
        }
    }
}
