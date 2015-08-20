using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple.RadGridSortAndPaging.Extensions
{
    public class ShortConverter : ITypeConverter
    {
        public object Convert(object sourceValue)
        {
            if (sourceValue == null || sourceValue == DBNull.Value)
                return null;

            return System.Convert.ToInt16(sourceValue);
        }
    }
}
