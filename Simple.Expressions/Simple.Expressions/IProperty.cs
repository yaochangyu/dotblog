using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Expressions
{
    public interface IProperty<T>
    {
        object GetValue(T instance, string memberName);

        void SetValue(T instance, string memberName, object newValue);

        object GetValue(object instance, string memberName);

        void SetValue(object instance, string memberName, object newValue);
    }
}