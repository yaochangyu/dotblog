using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.UseFluentAssertions
{
    public class Calculation
    {
        public int GetValue(object source)
        {
            var e = new FormatException("format error");
            var e1 = new InvalidOperationException("invalid operation", e);
            throw e1;
        }
    }
}