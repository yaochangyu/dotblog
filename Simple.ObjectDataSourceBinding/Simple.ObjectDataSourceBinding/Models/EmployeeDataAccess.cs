using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Simple.ObjectDataSourceBinding
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

        private static int s_Index = 5;

        //建立假資料
        private List<Employee> GetEmployeeItems()
        {
            var employees = new List<Employee>();
            employees.Add(new Employee() { Id = 1, Age = 51, Name = "yao", Email = "yao@aa.bb", Birthday = new DateTime(1981, 11, 12, 21, 44, 14) });
            employees.Add(new Employee() { Id = 2, Age = 22, Name = "kobe", Email = "kobe@aa.cc", Birthday = new DateTime(1966, 11, 11, 20, 35, 14) });
            employees.Add(new Employee() { Id = 3, Age = 33, Name = "jordan", Email = "jordan@aa.bb", Birthday = new DateTime(1971, 01, 12, 02, 33, 14) });
            employees.Add(new Employee() { Id = 4, Age = 43, Name = "bill", Email = "bill@aa.cc", Birthday = new DateTime(1980, 12, 22, 13, 25, 14) });
            return employees;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Employee employee)
        {
            employee.Id = s_Index;
            this.m_Employees.Add(employee);
            HttpContext.Current.Cache[SESSION_FAKE_DATA] = this.m_Employees;
            s_Index++;
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