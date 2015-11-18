using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simple.RadGridForObjectDataSOurce
{
    public class Employee
    {
        private int _age;
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age
        {
            get
            {
                if (!Birthday.HasValue)
                {
                    return -1;
                }
                var ticks = (DateTime.Today - Birthday).Value.Ticks;
                _age = new DateTime(ticks).Year;
                return _age;
            }
            // set { _age = value; }
        }

        public string Email { get; set; }

        public string Location { get; set; }

        public DateTime? Birthday { get; set; }
    }
}