using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Dynamic;
using NSubstitute;
using Simple.RadGridPaging.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LinqToObject_DateTime_Parse()
        {
            string[] chars = new[] { "DateTime.Parse(\"", "\")" };
            var testString = "(OrderDate = DateTime.Parse(\"1/28/2015 12:00:00 AM\")) AND (RequiredDate = DateTime.Parse(\"2/4/2015 12:00:00 AM\"))";
            var filter = Order.GetOrders().AsQueryable().Where(testString);
            Assert.IsTrue(filter.Count() >= 0);
        }

        [TestMethod]
        public void Mock_DbContext()
        {
            //arrange
            var data = new List<Employee>()
            {
                new Employee() { EmployeeID = 1, LastName = "余", FirstName = "小章" },
                new Employee() { EmployeeID = 2, LastName = "王", FirstName = "小華" },
                new Employee() { EmployeeID = 3, LastName = "蔡", FirstName = "比巴" },
            }.AsQueryable();

            //var mockDbSet = Substitute.For<IDbSet<Employee>, DbSet<Employee>>();
            //mockDbSet.Provider.Returns(data.Provider);
            //mockDbSet.Expression.Returns(data.Expression);
            //mockDbSet.ElementType.Returns(data.ElementType);
            //mockDbSet.GetEnumerator().Returns(data.GetEnumerator());

            var mockDbSet = Substitute.For<IDbSet<Employee>, DbSet<Employee>>().Initialize(data);

            var mockDbContext = Substitute.For<NorthwindDbContext>();
            mockDbContext.Employees.Returns(mockDbSet);

            //act
            var query = mockDbContext.Employees.FirstOrDefault(p => p.EmployeeID == 2);

            //assert
            Assert.AreEqual("小華", query.FirstName);
        }
    }


    public static class ExtentionMethods
    {
        public static IDbSet<T> Initialize<T>(this IDbSet<T> dbSet, IQueryable<T> data) where T : class
        {
            dbSet.Provider.Returns(data.Provider);
            dbSet.Expression.Returns(data.Expression);
            dbSet.ElementType.Returns(data.ElementType);
            dbSet.GetEnumerator().Returns(data.GetEnumerator());
            return dbSet;
        }
    }

    public class Order
    {
        internal static IEnumerable<Order> GetOrders()
        {
            List<Order> result = new List<Order>();
            result.Add(new Order() { OrderDate = new DateTime(1922, 02, 11), RequiredDate = new DateTime(1933, 10, 22) });
            return result;
        }

        public DateTime OrderDate { get; set; }

        public DateTime RequiredDate { get; set; }
    }
}