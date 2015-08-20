﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple.RadGridSortAndPaging.Extensions
{
    public class StringConverter : ITypeConverter
    {
        public object Convert(object sourceValue)
        {
            if (sourceValue == null || sourceValue == DBNull.Value)
                return null;

            return sourceValue.ToString();
        }
    }


}
