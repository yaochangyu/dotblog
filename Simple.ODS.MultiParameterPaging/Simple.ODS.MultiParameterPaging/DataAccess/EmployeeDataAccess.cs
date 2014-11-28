using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace Simple.ODS.MultiParameterPaging
{
    [DataObject(true)]
    public class EmployeeDataAccess
    {
        private const string CACHE_FAKE_DATA = "CACHE_FAKE_DATA";
        private List<Employee> m_Employees = null;

        public EmployeeDataAccess()
        {
            if (HttpContext.Current.Cache[CACHE_FAKE_DATA] == null)
            {
                this.m_Employees = GetEmployeeItems();
                HttpContext.Current.Cache[CACHE_FAKE_DATA] = this.m_Employees;
            }
            else
            {
                this.m_Employees = HttpContext.Current.Cache[CACHE_FAKE_DATA] as List<Employee>;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<string> GetLocations()
        {
            return this.m_Employees.Select(p => p.Location).Distinct();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public int GetEmployeeCount(string location, int maximumRows, int startRowIndex, string orderBy)
        {
            Func<Employee, bool> condition = null;
            if (location == "ALL")
            {
                condition = e => true;
            }
            else
            {
                condition = e => e.Location == location;
            }
            var queryCount = this.m_Employees.Count(condition);
            return queryCount;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<Employee> GetEmployees(string location, int maximumRows, int startRowIndex, string orderBy)
        {
            Func<Employee, bool> condition = null;
            if (location == "ALL")
            {
                condition = e => true;
            }
            else
            {
                condition = e => e.Location == location;
            }
            if (string.IsNullOrWhiteSpace(orderBy))
            {
                return this.m_Employees.Where(condition)
                                       .OrderBy("Id")
                                       .Skip(startRowIndex)
                                       .Take(maximumRows);
            }

            //控制項的行為都不一樣，所得到的orderBy也會不一樣
            if (orderBy.Contains("DESC"))
            {
                var split = orderBy.Split(' ');
                var columnName = split[0];
                return this.m_Employees.Where(condition)
                                       .OrderByDescending(columnName)
                                       .Skip(startRowIndex)
                                       .Take(maximumRows);
            }
            else
            {
                return this.m_Employees.Where(condition)
                                       .OrderBy(orderBy)
                                       .Skip(startRowIndex)
                                       .Take(maximumRows);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<Employee> GetAllEmployees()
        {
            return this.m_Employees;
        }

        //建立假資料
        private List<Employee> GetEmployeeItems()
        {
            var employees = new List<Employee>();
            employees.Add(new Employee() { Id = 1, Location = "T", Age = 49, Name = "yao", Email = "yao@aa.bb", Birthday = new DateTime(1981, 11, 12, 21, 44, 14) });
            employees.Add(new Employee() { Id = 2, Location = "K", Age = 22, Name = "Kobe", Email = "kobe@aa.cc", Birthday = new DateTime(1966, 08, 11, 20, 35, 14) });
            employees.Add(new Employee() { Id = 3, Location = "K", Age = 33, Name = "Jordan", Email = "jordan@aa.bb", Birthday = new DateTime(1971, 01, 12, 02, 33, 14) });
            employees.Add(new Employee() { Id = 4, Location = "T", Age = 61, Name = "Duke", Email = "Duke@aa.cc", Birthday = new DateTime(1981, 02, 02, 17, 25, 14) });
            employees.Add(new Employee() { Id = 5, Location = "T", Age = 26, Name = "Bill", Email = "bill@aa.cc", Birthday = new DateTime(1980, 03, 12, 13, 25, 14) });
            employees.Add(new Employee() { Id = 6, Location = "T", Age = 25, Name = "Elliot", Email = "Elliot@aa.cc", Birthday = new DateTime(1983, 02, 22, 13, 25, 14) });
            employees.Add(new Employee() { Id = 7, Location = "K", Age = 36, Name = "Gabe", Email = "Gabe@aa.cc", Birthday = new DateTime(1940, 12, 22, 09, 25, 14) });
            employees.Add(new Employee() { Id = 8, Location = "K", Age = 19, Name = "George", Email = "George@aa.cc", Birthday = new DateTime(1987, 03, 22, 13, 25, 14) });
            employees.Add(new Employee() { Id = 9, Location = "T", Age = 21, Name = "Ian", Email = "Ian@aa.cc", Birthday = new DateTime(1940, 09, 23, 13, 04, 14) });
            employees.Add(new Employee() { Id = 10, Location = "K", Age = 28, Name = "Kevin", Email = "Kevin@aa.cc", Birthday = new DateTime(1950, 12, 22, 13, 25, 14) });
            return employees;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Employee employee)
        {
            var max = this.m_Employees.Max(p => p.Id);
            employee.Id = max++;
            this.m_Employees.Insert(0, employee);
            //HttpContext.Current.Cache[SESSION_FAKE_DATA] = this.m_Employees;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(Employee employee)
        {
            var queryIndex = (from element in this.m_Employees
                              where element.Id == employee.Id
                              let index = this.m_Employees.IndexOf(element)
                              select new { Index = index, Employee = element }).FirstOrDefault();

            if (queryIndex == null)
            {
                return false;
            }

            this.m_Employees[queryIndex.Index] = employee;
            //HttpContext.Current.Cache[SESSION_FAKE_DATA] = this.m_Employees;
            return true;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public bool Delete(Employee employee)
        {
            var query = (from element in this.m_Employees
                         where element.Id == employee.Id
                         select element).FirstOrDefault();

            if (query == null)
            {
                return false;
            }
            this.m_Employees.Remove(query);
            //HttpContext.Current.Cache[SESSION_FAKE_DATA] = this.m_Employees;
            return true;
        }
    }
}