using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Simple.DataBindingForColumnGenerator
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
        public IEnumerable<Employee> GetEmployees()
        {
            return this.m_Employees;
        }

        //建立假資料
        private List<Employee> GetEmployeeItems()
        {
            var employees = new List<Employee>();
            employees.Add(new Employee() { Id = 1, Age = 51, Name = "name1", Email = "email1" });
            employees.Add(new Employee() { Id = 2, Age = 22, Name = "name2", Email = "email2" });
            employees.Add(new Employee() { Id = 3, Age = 33, Name = "name3", Email = "email3" });
            employees.Add(new Employee() { Id = 4, Age = 43, Name = "name4", Email = "email4" });
            return employees;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Employee MessageItem)
        {
            this.m_Employees.Add(MessageItem);
            HttpContext.Current.Cache[SESSION_FAKE_DATA] = this.m_Employees;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(Employee MessageItem)
        {
            var query = (from element in this.m_Employees
                         where element.Id == MessageItem.Id
                         select element).FirstOrDefault();

            if (query == null)
            {
                return false;
            }
            query.Id = MessageItem.Id;
            query.Email = MessageItem.Email;
            query.Age = MessageItem.Age;
            query.Name = MessageItem.Name;
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