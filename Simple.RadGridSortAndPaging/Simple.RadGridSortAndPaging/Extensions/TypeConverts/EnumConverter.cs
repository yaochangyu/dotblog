using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simple.RadGridSortAndPaging.Extensions
{
    public class EnumConverter : ITypeConverter
    {
        public object Convert(object sourceValue)
        {
            throw new NotImplementedException();
        }

        public object Convert(Type EnumType, object sourceValue)
        {
            if (!EnumType.IsEnum)
                throw new InvalidOperationException("ERROR_TYPE_IS_NOT_ENUMERATION");

            return System.Convert.ChangeType(Enum.Parse(EnumType, sourceValue.ToString()), EnumType);
        }
    }
}