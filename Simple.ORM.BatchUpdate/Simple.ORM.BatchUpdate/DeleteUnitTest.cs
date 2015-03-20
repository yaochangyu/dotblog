using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Simple.ORM.InsertBigRow
{
    [TestClass]
    public class DeleteUnitTest
    {
        [TestInitialize]
        public void Before()
        {
            Delete();
            ZZZProject insert = new ZZZProject();
            insert.Insert(Core.s_rowCount);
        }

        internal static List<TestInfo> s_testInfos = null;

        public DeleteUnitTest()
        {
            if (s_testInfos == null)
            {
                s_testInfos = new List<TestInfo>();
            }
        }

        [ClassCleanup]
        public static void ClassAfter()
        {
            Console.WriteLine("Detete Test：");

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
        public void Delete_Test()
        {
            var watch = Stopwatch.StartNew();
            Delete();
            watch.Stop();
            Console.WriteLine("Detete Table cost time:{0} ms", watch.Elapsed.TotalMilliseconds);
        }

        [TestMethod]
        public void EF6_Delete_Test()
        {
            IAccess EF6 = new EF6();

            var test1 = new TestInfo(() =>
            {
                var datas = EF6.Delete(Core.s_rowCount);
                return EF6;
            }, "EF Delete");
            test1.Run(Core.s_runTimes);

            s_testInfos.Add(test1);
        }

        [TestMethod]
        public void ZZZ_Project_Delete_Test()
        {
            IAccess ZZZProject = new ZZZProject();

            var tset = new TestInfo(() =>
            {
                var datas = ZZZProject.Delete(Core.s_rowCount);
                return ZZZProject;
            }, "ZP Delete");
            tset.Run(Core.s_runTimes);

            s_testInfos.Add(tset);
        }

        [TestMethod]
        public void ZZZ_Delete_Result()
        {
        }
    }
}