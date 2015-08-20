using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple.RadGridSortAndPaging.Extensions
{
    public class BooleanConverter : ITypeConverter
    {
        public object Convert(object sourceValue)
        {
            if (sourceValue == null || sourceValue == DBNull.Value)
                return null;

            if (string.IsNullOrEmpty(sourceValue.ToString()))
                return null;
            else if (sourceValue.ToString() == "0")
                return false;
            else if (sourceValue.ToString() == "1")
                return true;
            else
                return System.Convert.ToBoolean(sourceValue);
        }
    }
}
