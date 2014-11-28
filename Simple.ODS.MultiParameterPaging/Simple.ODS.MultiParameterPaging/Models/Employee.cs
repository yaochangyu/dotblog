using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simple.ODS.MultiParameterPaging
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Location { get; set; }

        public DateTime? Birthday { get; set; }
    }
}