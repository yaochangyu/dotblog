using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple.ORM.BatchUpdate
{
    [TestClass]
    public class UpdateUnitTest
    {
        internal static List<TestInfo> s_testInfos = null;

        public UpdateUnitTest()
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
            ZZZProject z = new ZZZProject();
            z.Insert(Core.s_rowCount);
        }

        [ClassCleanup]
        public static void ClassAfter()
        {
            Console.WriteLine("Update Test：");

            var testInfos = s_testInfos.OrderBy(p => p.CostTime);
            foreach (var info in testInfos)
            {
                Console.WriteLine(info.Message);
            }
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
        public void ZZZ_ProjectUpdate_Test()
        {
            IAccess ZZZProject = new ZZZProject();

            var tset = new TestInfo(() =>
            {
                var datas = ZZZProject.Update(Core.s_rowCount);
                return ZZZProject;
            }, "ZProject".PadRight(13, ' ') + "Update");
            tset.Run(Core.s_runTimes);

            s_testInfos.Add(tset);
        }

        [TestMethod]
        public void EF6_Update_Test()
        {
            IAccess EF6 = new EF6();

            var test1 = new TestInfo(() =>
            {
                var datas = EF6.Update(Core.s_rowCount);
                return EF6;
            }, "EF".PadRight(16, ' ') + "Update");
            test1.Run(Core.s_runTimes);

            s_testInfos.Add(test1);
        }

        [TestMethod]
        public void Dapper_Update_Test()
        {
            IAccess dapper = new DapperAccess();

            var test1 = new TestInfo(() =>
            {
                var datas = dapper.Update(Core.s_rowCount);
                return dapper;
            }, "Dapper".PadRight(12, ' ') + "Update");
            test1.Run(Core.s_runTimes);

            s_testInfos.Add(test1);
        }

        [TestMethod]
        public void ZZZ_UpdateResult()
        {
        }
    }
}