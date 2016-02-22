using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.Mock;
using System;
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

            var httpContext = FakeHttpContextManager.CreateHttpContext()
                .SetIdentity("yao")
                ;
            ws.CurrentHttpContext = httpContext;
            var actual = ws.HelloWorld();
            Assert.AreEqual(expected, actual);
        }
    }
}