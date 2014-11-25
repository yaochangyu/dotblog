using Simple.ObjectDataSourcePaging.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace Simple.ObjectDataSourcePaging.DataAccess
{
    [DataObject(true)]
    public class EmployeeDataAccess
    {
        private const string SESSION_FAKE_DATA = "SESSION_FAKE_DATA";
        private List<Employee> m_Employees = null;

        public EmployeeDataAccess()
        {
            if (HttpContext.Current.Cache[SESSION_FAKE_DATA] == null)
            {
                this.m_Employees = GetEmployeeItems();
                HttpContext.Current.Cache[SESSION_FAKE_DATA] = this.m_Employees;
            }
            else
            {
                this.m_Employees = HttpContext.Current.Cache[SESSION_FAKE_DATA] as List<Employee>;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public int GetEmployees(string columnName)
        {
            return this.m_Employees.Count;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public int GetEmployeeCount()
        {
            return this.m_Employees.Count;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<Employee> GetEmployees(int maximumRows, int startRowIndex, string orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy))//網頁第一次進來orderby為空，所以給它預設值
            {
                orderBy = "Id";
            }
            return this.m_Employees.OrderBy(orderBy).Skip(startRowIndex).Take(maximumRows);
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

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Employee employee)
        {
            var max = this.m_Employees.Max(p => p.Id);
            employee.Id = max++;
            this.m_Employees.Add(employee);
            HttpContext.Current.Cache[SESSION_FAKE_DATA] = this.m_Employees;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(Employee employee)
        {
            var query = (from element in this.m_Employees
                         where element.Id == employee.Id
                         select element).FirstOrDefault();

            if (query == null)
            {
                return false;
            }

            query.Email = employee.Email;
            query.Age = employee.Age;
            query.Name = employee.Name;
            HttpContext.Current.Cache[SESSION_FAKE_DATA] = this.m_Employees;
            return true;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public bool Delete(Employee MessageItem)
        {
            var query = (from element in this.m_Employees
                         where element.Id == MessageItem.Id
                         select element).FirstOrDefault();
            if (query == null)
            {
                return false;
            }
            this.m_Employees.Remove(query);
            HttpContext.Current.Cache[SESSION_FAKE_DATA] = this.m_Employees;
            return true;
        }
    }
}