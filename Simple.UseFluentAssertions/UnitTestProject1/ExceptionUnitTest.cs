using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.UseFluentAssertions;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class ExceptionUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Calculation calculation = new Calculation();
            calculation.Invoking(p => p.GetValue(null));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Calculation calculation = new Calculation();
            Action action = () => calculation.GetValue(null);
            action.ShouldThrow<InvalidOperationException>();
        }

        [TestMethod]
        public void TestMethod3()
        {
            Calculation calculation = new Calculation();
            Action action = () => calculation.GetValue(null);
            action.ShouldThrow<InvalidOperationException>()
                .WithMessage("invalid operation");
        }

        [TestMethod]
        public void TestMethod4()
        {
            Calculation calculation = new Calculation();
            Action action = () => calculation.GetValue(null);
            action.ShouldThrow<InvalidOperationException>().Where(p => p.Message.Contains("invalid operation"));
        }

        [TestMethod]
        public void TestMethod5()
        {
            Calculation calculation = new Calculation();
            Action action = () => calculation.GetValue(null);
            action.ShouldThrow<InvalidOperationException>().WithMessage("*oper*");
            action.ShouldThrow<InvalidOperationException>().WithMessage("invalid*");
        }

        [TestMethod]
        public void TestMethod6()
        {
            Calculation calculation = new Calculation();
            Action action = () => calculation.GetValue(null);
            action.ShouldThrow<InvalidOperationException>("*oper*").WithInnerException<FormatException>("*format*");
        }
    }
}