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
            var config1 = (MySection)ConfigurationManager.GetSection("MySectionGroup/MySection1");
            var config2 = (MySection)ConfigurationManager.GetSection("MySectionGroup/MySection2");

            Assert.AreEqual("9571", config1.Code);
            Assert.AreEqual(1, config1.Member.Id);
            Assert.AreEqual("MySection1", config1.Member.Name);

            Assert.AreEqual("9572", config2.Code);
            Assert.AreEqual(2, config2.Member.Id);
            Assert.AreEqual("MySection2", config2.Member.Name);
        }

        [TestMethod]
        public void MembersTestMethod()
        {
            var config = (MySection)ConfigurationManager.GetSection("MySection");

            Assert.AreEqual(1, config.Members[0].Id);
            Assert.AreEqual("Yao1", config.Members[0].Name);
        }
    }
}