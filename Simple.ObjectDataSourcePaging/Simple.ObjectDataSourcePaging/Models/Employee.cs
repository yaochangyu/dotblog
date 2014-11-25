using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simple.ObjectDataSourcePaging.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public DateTime? Birthday { get; set; }
    }
}