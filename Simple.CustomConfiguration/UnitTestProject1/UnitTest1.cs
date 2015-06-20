using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.CustomConfiguration;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LoadFile_TestMethod()
        {
            var filePath = Directory.GetCurrentDirectory() + "\\" + "App2.config";

            var mySection = (MySection)ConfigurationManager.GetSection("MySection");
            MySection.LoadFile(filePath, false);

            Assert.AreEqual("36", mySection.Code);
        }

        [TestMethod]
        public void LoadFile_CreateDefault_TestMethod()
        {
            var filePath = Directory.GetCurrentDirectory() + "\\" + "App1.config";

            MySection.LoadFile(filePath, true);
            var section = (MySection)ConfigurationManager.GetSection("Section");
            var mySection = (MySection)ConfigurationManager.GetSection("MySection");
            Assert.AreEqual("9999", section.Code);
            Assert.AreEqual(100, section.Member.Id);
            Assert.AreEqual("Sys", section.Member.Name);

            Assert.AreEqual("23", mySection.Code);
            Assert.AreEqual(2, mySection.Member.Id);
            Assert.AreEqual("余小章", mySection.Member.Name);
        }

        [TestMethod]
        public void CreateAndLoadDefault_TestMethod1()
        {
            var section = (MySection)ConfigurationManager.GetSection("Section");
            var mySection = (MySection)ConfigurationManager.GetSection("MySection");
            Assert.AreEqual("9999", section.Code);
            Assert.AreEqual(100, section.Member.Id);
            Assert.AreEqual("Sys", section.Member.Name);

            Assert.AreEqual("23", mySection.Code);
            Assert.AreEqual(2, mySection.Member.Id);
            Assert.AreEqual("余小章", mySection.Member.Name);
        }

        [TestMethod]
        public void GetUnitTestAssembly_TestMethod()
        {
            /* Preparing test start */
            Assembly assembly = Assembly.GetCallingAssembly();

            AppDomainManager manager = new AppDomainManager();
            FieldInfo entryAssemblyfield = manager.GetType().GetField("m_entryAssembly", BindingFlags.Instance | BindingFlags.NonPublic);
            entryAssemblyfield.SetValue(manager, assembly);

            AppDomain domain = AppDomain.CurrentDomain;
            FieldInfo domainManagerField = domain.GetType().GetField("_domainManager", BindingFlags.Instance | BindingFlags.NonPublic);
            domainManagerField.SetValue(domain, manager);
            var expected = "Microsoft.VisualStudio.TestPlatform.Extensions.VSTestIntegration.dll";
            var actual = Path.GetFileName(assembly.Location);
            Assert.AreEqual(expected, actual);
        }

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