using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Simple.DataBindingForColumnGenerator
{
    public class Employee
    {
        [DisplayName("流水號")]
        public int Id { get; set; }

        [DisplayName("姓名")]
        public string Name { get; set; }

        [DisplayName("年齡")]
        public int Age { get; set; }

        [DisplayName("信箱")]
        public string Email { get; set; }
    }
}