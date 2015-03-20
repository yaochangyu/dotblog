using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple.ORM.BatchUpdate
{
    [TestClass]
    public class InsertUnitTest
    {
        internal static List<TestInfo> s_testInfos = null;

        public InsertUnitTest()
        {
            if (s_testInfos == null)
            {
                s_testInfos = new List<TestInfo>();
            }
        }

        [TestInitialize]
        public void Before()
        {
            Delete();
        }

        [ClassCleanup]
        public static void ClassAfter()
        {
            Console.WriteLine("Insert Test：");

            var testInfos = s_testInfos.OrderBy(p => p.CostTime);
            foreach (var info in testInfos)
            {
                Console.WriteLine(info.Message);
            }
        }

        [TestCleanup]
        public void After()
        {
            Delete();
        }

        private static void Delete()
        {
            using (var db = new TargetDbContext())
            {
                db.Database.ExecuteSqlCommand("DELETE FactProductInventory");
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void EF6_Insert_Test()
        {
            IAccess EF6 = new EF6();

            var test1 = new TestInfo(() =>
            {
                var datas = EF6.Insert(Core.s_rowCount);
                return EF6;
            }, "EF Insert");
            test1.Run(Core.s_runTimes);

            s_testInfos.Add(test1);
        }

        [TestMethod]
        public void ZZZ_Project_Insert_Test()
        {
            IAccess ZZZProject = new ZZZProject();

            var tset = new TestInfo(() =>
            {
                var datas = ZZZProject.Insert(Core.s_rowCount);
                return ZZZProject;
            }, "ZP Delete");
            tset.Run(Core.s_runTimes);

            s_testInfos.Add(tset);
        }

        [TestMethod]
        public void ZZZ_InsertResult()
        {
        }
    }
}