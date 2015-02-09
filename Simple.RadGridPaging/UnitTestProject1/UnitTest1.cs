using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.RadGridPaging;
using System.Linq.Dynamic;
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
