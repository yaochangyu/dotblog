using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Expressions
{
    public class ReflectionProperty<T> : IProperty<T>
    {
        public object GetValue(T instance, string memberName)
        {
            return Get(instance, memberName);
        }

        public void SetValue(T instance, string memberName, object newValue)
        {
            Set(instance, memberName, newValue);
        }

        public object GetValue(object instance, string memberName)
        {
            return Get(instance, memberName);
        }

        public void SetValue(object instance, string memberName, object newValue)
        {
            Set(instance, memberName, newValue);
        }

        private static void Set(object instance, string memberName, object newValue)
        {
            if (instance == null)
            {
                return;
            }
            var propertyInfo = instance.GetType().GetProperty(memberName);
            if (propertyInfo == null)
            {
                return;
            }
            propertyInfo.SetValue(instance, newValue, null);
        }

        private static object Get(object instance, string memberName)
        {
            if (instance == null)
            {
                return null;
            }
            var propertyInfo = instance.GetType().GetProperty(memberName);
            if (propertyInfo == null)
            {
                return null;
            }

            return propertyInfo.GetValue(instance, null);
        }
    }
}