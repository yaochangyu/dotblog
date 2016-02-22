using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Simple.Mock;
using System;
using System.Web;
using System.Web.UI.WebControls;
using WebApplication1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var expected = "Hello, yao";
            WebService1 ws = new WebService1();

            HttpContext.Current = FakeHttpContextManager.CreateHttpContext().SetIdentity("yao");

            var actual = ws.HelloWorld1();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var expected = "Hello, yao";
            WebService1 ws = new WebService1();
            var mock = Substitute.For<ICurrentUser>();
            mock.IsAuthenticated().Returns(true);
            mock.GetName().Returns("yao");

            ws.CurrentUser = mock;
            var actual = ws.HelloWorld2();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var expected = "Hello, yao";
            WebService1 ws = new WebService1();

            var httpContext = FakeHttpContextManager.CreateHttpContextBase()
                .SetIdentity("yao")
                ;
            ws.CurrentHttpContext = httpContext;
            var actual = ws.HelloWorld3();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MockQueryString_TestMethod()
        {
            var expected1 = "yao";
            var expected2 = "1233";
            WebService1 ws = new WebService1();

            var httpContext = FakeHttpContextManager.CreateHttpContextBase()
                .SetQueryString("http://aa.com?name=yao&id=1233")
                ;
            ws.CurrentHttpContext = httpContext;
            var actual1 = ws.GetQueryValue("name");
            var actual2 = ws.GetQueryValue("id");
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }
    }
}