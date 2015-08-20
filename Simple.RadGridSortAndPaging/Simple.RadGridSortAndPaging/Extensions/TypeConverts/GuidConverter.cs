using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simple.RadGridSortAndPaging.Extensions.TypeConverter
{
    public class GuidConverter : ITypeConverter
    {
        public object Convert(object sourceValue)
        {
            if (sourceValue == null || sourceValue == DBNull.Value)
                return null;
            Guid result;
            if (!Guid.TryParse(sourceValue.ToString(), out result))
            {
                return Guid.Empty;
            }
            return result;
        }
    }
}