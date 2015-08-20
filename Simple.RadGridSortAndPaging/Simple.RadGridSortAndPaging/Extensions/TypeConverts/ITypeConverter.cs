using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple.RadGridSortAndPaging.Extensions
{
    public interface ITypeConverter
    {
        object Convert(object sourceValue);
    }
}
