using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.CustomConfiguration;
using System;
using System.Configuration;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SectionTestMethod()
        {
            var config = (MySection)ConfigurationManager.GetSection("MySection");
            Assert.AreEqual("23", config.Code);
            Assert.AreEqual(2, config.Member.Id);
            Assert.AreEqual("余小章", config.Member.Name);
        }

        [TestMethod]
        public void SectoinGroupTestMethod()
        {
            var config = (MySection)ConfigurationManager.GetSection("MySectionGroup/MySection1");
        }

        [TestMethod]
        public void TestMethod3()
        {
            var config = (MySection)ConfigurationManager.GetSection("MySection");

            foreach (MemberElement member in config.Members)
            {
            }
        }
    }
}