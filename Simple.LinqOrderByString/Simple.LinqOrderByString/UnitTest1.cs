using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;

namespace Simple.LinqOrderByString
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void OrderBy_GetPropertyValue_TestMethod()
        {
            var employees = Employee.GetAllEmployees();
            var expected = 8;
            var actual = employees.OrderBy(e => GetPropertyValue(e, "Age")).First().Id;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IEnumerable_OrderBy_Extension_TestMethod()
        {
            var employees = Employee.GetAllEmployees();
            var expected = 9;
            var actual = employees.OrderBy("Birthday").First().Id;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IEnumerable_OrderByDescending_Extension_TestMethod()
        {
            var employees = Employee.GetAllEmployees();
            var expected = 9;
            var actual = employees.OrderByDescending("Birthday").Last().Id;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IQuerabl_OrderBy_Extension_TestMethod()
        {
            var employees = Employee.GetAllEmployees().AsQueryable();
            var expected = 9;
            var actual = employees.OrderBy("Birthday").First().Id;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IQuerable_OrderByDescending_Extension_TestMethod()
        {
            var employees = Employee.GetAllEmployees().AsQueryable();
            var expected = 9;
            var actual = employees.OrderBy("Birthday").First().Id;

            Assert.AreEqual(expected, actual);
        }

        private object GetPropertyValue<TSource>(TSource source, string propertyName)
        {
            PropertyInfo propertyInfo = typeof(TSource).GetProperty(propertyName);
            var result = propertyInfo.GetValue(source, null);
            return result;
        }
    }
}