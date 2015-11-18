using Faker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;

namespace Simple.RadGridForObjectDataSOurce
{
    [DataObject(true)]
    public class EmployeeDataSourceManager
    {
        private const string CACHE_FAKE_DATA = "CACHE_FAKE_DATA";
        private IEnumerable<Employee> _employees = null;

        public EmployeeDataSourceManager()
        {
            if (HttpContext.Current.Cache[CACHE_FAKE_DATA] == null)
            {
                this._employees = GenerateFakeEmployeeItems();
                HttpContext.Current.Cache[CACHE_FAKE_DATA] = this._employees;
            }
            else
            {
                this._employees = HttpContext.Current.Cache[CACHE_FAKE_DATA] as IEnumerable<Employee>;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<string> GetLocations()
        {
            return this._employees.Select(p => p.Location).Distinct();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public int GetEmployeeCount(int startRowIndex, int maximumRows, string filterExpressions, string sortExpressions)
        {
            return _queryCount;
        }

        private int _queryCount;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<Employee> GetEmployees(int startRowIndex, int maximumRows, string filterExpressions, string sortExpressions)
        {
            IEnumerable<Employee> query = this._employees.AsQueryable();
            if (string.IsNullOrWhiteSpace(filterExpressions) == false)
            {
                query = query.Where(filterExpressions);
            }
            this._queryCount = query.Count();
            if (string.IsNullOrWhiteSpace(sortExpressions))
            {
                query = query.OrderBy(p => p.Id);
            }
            else
            {
                query = query.OrderBy(sortExpressions);
            }

            query = query.Skip(startRowIndex).Take(maximumRows);
            var result = query.ToList();
            return result;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<Employee> GetAllEmployees()
        {
            return this._employees;
        }

        //建立假資料
        private List<Employee> GenerateFakeEmployeeItems()
        {
            var employees = new List<Employee>();
            for (int i = 0; i < 100; i++)
            {
                var employee = new Employee();
                employee.Id = i + 1;
                employee.Name = NameFaker.Name();
                employee.Birthday = DateTimeFaker.DateTimeBetweenYears(50);
                employee.Location = LocationFaker.Country();
                employee.Email = InternetFaker.Email();

                employees.Add(employee);
            }

            return employees;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Employee employee)
        {
            var max = this._employees.Max(p => p.Id);
            employee.Id = max++;
            var newEmployee = this._employees.ToList();
            newEmployee.Insert(0, employee);
            HttpContext.Current.Cache[CACHE_FAKE_DATA] = newEmployee;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(Employee employee)
        {
            var newEmployee = this._employees.ToList();

            var queryIndex = (from element in this._employees
                              where element.Id == employee.Id
                              let index = newEmployee.IndexOf(element)
                              select new { Index = index, Employee = element }).FirstOrDefault();

            if (queryIndex == null)
            {
                return false;
            }

            newEmployee[queryIndex.Index] = employee;
            HttpContext.Current.Cache[CACHE_FAKE_DATA] = newEmployee;

            return true;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public bool Delete(Employee employee)
        {
            var newEmployee = this._employees.ToList();
            var query = (from element in this._employees
                         where element.Id == employee.Id
                         select element).FirstOrDefault();

            if (query == null)
            {
                return false;
            }
            newEmployee.Remove(query);
            HttpContext.Current.Cache[CACHE_FAKE_DATA] = newEmployee;

            return true;
        }
    }
}