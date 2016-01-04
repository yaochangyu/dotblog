using BLL;
using DAL.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace IntegrateUnitTestProject
{
    [TestClass]
    [DeploymentItem("App_Data\\TestDB.mdf", "App_Data")]
    public class UnitTes1
    {
        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

            AppDomain.CurrentDomain.SetData(
                "DataDirectory",
                Path.Combine(context.TestDeploymentDir, "App_Data"));
        }

        [TestMethod]
        public void BLL_TestMethod()
        {
            var expected = 2;
            FlowBLL bll = new FlowBLL();
            var members = bll.GetMembers();
            var actual = members.Count();
            Assert.AreEqual(expected, actual);
        }
    }
}