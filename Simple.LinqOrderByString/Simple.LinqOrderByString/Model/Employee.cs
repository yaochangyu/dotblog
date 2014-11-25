using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.LinqOrderByString
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public DateTime? Birthday { get; set; }

        public static IEnumerable<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();
            employees.Add(new Employee() { Id = 1, Age = 49, Name = "yao", Email = "yao@aa.bb", Birthday = new DateTime(1981, 11, 12, 21, 44, 14) });
            employees.Add(new Employee() { Id = 2, Age = 22, Name = "Kobe", Email = "kobe@aa.cc", Birthday = new DateTime(1966, 08, 11, 20, 35, 14) });
            employees.Add(new Employee() { Id = 3, Age = 33, Name = "Jordan", Email = "jordan@aa.bb", Birthday = new DateTime(1971, 01, 12, 02, 33, 14) });
            employees.Add(new Employee() { Id = 4, Age = 61, Name = "Duke", Email = "Duke@aa.cc", Birthday = new DateTime(1981, 02, 02, 17, 25, 14) });
            employees.Add(new Employee() { Id = 5, Age = 26, Name = "Bill", Email = "bill@aa.cc", Birthday = new DateTime(1980, 03, 12, 13, 25, 14) });
            employees.Add(new Employee() { Id = 6, Age = 25, Name = "Elliot", Email = "Elliot@aa.cc", Birthday = new DateTime(1983, 02, 22, 13, 25, 14) });
            employees.Add(new Employee() { Id = 7, Age = 36, Name = "Gabe", Email = "Gabe@aa.cc", Birthday = new DateTime(1940, 12, 22, 09, 25, 14) });
            employees.Add(new Employee() { Id = 8, Age = 19, Name = "George", Email = "George@aa.cc", Birthday = new DateTime(1987, 03, 22, 13, 25, 14) });
            employees.Add(new Employee() { Id = 9, Age = 21, Name = "Ian", Email = "Ian@aa.cc", Birthday = new DateTime(1940, 09, 23, 13, 04, 14) });
            employees.Add(new Employee() { Id = 10, Age = 28, Name = "Kevin", Email = "Kevin@aa.cc", Birthday = new DateTime(1950, 12, 22, 13, 25, 14) });
            return employees;
        }
    }
}