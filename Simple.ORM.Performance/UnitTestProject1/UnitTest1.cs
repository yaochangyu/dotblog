using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.ORM.Performance;
using Simple.ORM.Performance.DataAdapter;
using Simple.ORM.Performance.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var runTimes = 1;
            IFlowDataAccess dapper = new DapperDAO();
            IFlowDataAccess ef = new EntityDAO();
            IFlowDataAccess efNoTrack = new EntityNoTrackDAO();
            IFlowDataAccess dataReaderLoad = new DataReaderLoadDAO();
            IFlowDataAccess dataReaderLoadDataRow = new DataReaderLoadDataRowDAO();
            IFlowDataAccess dataReaderDynamicMappingDAO = new DataReaderExpressionMappingDAO();
            IFlowDataAccess dataReaderReflectMappingDAO = new DataReaderReflectMappingDAO();
            IFlowDataAccess dataReaderDAO = new DataReaderDAO();
            IFlowDataAccess dataAdapterDAO = new DataAdapterDAO();

            var test1 = new TestInfo(() =>
            {
                var datas = dapper.GetAllInventory();
                return dapper;
            }, "Dapper");
            test1.Run(runTimes);

            var test2 = new TestInfo(() =>
            {
                var datas = ef.GetAllInventory();
                return ef;
            }, "EF");
            test2.Run(runTimes);

            var test3 = new TestInfo(() =>
            {
                var datas = efNoTrack.GetAllInventory();
                return efNoTrack;
            }, "EF No Track");
            test3.Run(runTimes);

            var test4 = new TestInfo(() =>
            {
                var datas = dataReaderLoad.GetAllInventory();
                return dataReaderLoad;
            }, "DataReader for DataTable.Load");
            test4.Run(runTimes);

            var test5 = new TestInfo(() =>
            {
                var datas = dataReaderLoadDataRow.GetAllInventory();
                return dataReaderLoadDataRow;
            }, "DataReader for DataTable.LoadDataRow");
            test5.Run(runTimes);

            var test6 = new TestInfo(() =>
            {
                var datas = dataReaderDynamicMappingDAO.GetAllInventory();
                return dataReaderDynamicMappingDAO;
            }, "DataReader for Expression Mapping");
            test6.Run(runTimes);

            var test7 = new TestInfo(() =>
            {
                var datas = dataReaderReflectMappingDAO.GetAllInventory();
                return dataReaderReflectMappingDAO;
            }, "DataReader for Reflect Mapping");
            test7.Run(runTimes);

            var test8 = new TestInfo(() =>
            {
                var datas = dataReaderDAO.GetAllInventory();
                return dataReaderDAO;
            }, "DataReader");
            test8.Run(runTimes);

            var test9 = new TestInfo(() =>
            {
                var datas = dataAdapterDAO.GetAllInventory();
                return dataAdapterDAO;
            }, "DataAdapter use Fill");
            test9.Run(runTimes);
            Console.Write("");

            Console.WriteLine("排名，最快的在前面：");

            List<TestInfo> testInfos = new List<TestInfo>()
            {
                test1,
                test2,
                test3,
                test4,
                test5,
                test6,
                test7,
                test8,
                test9
            };

            var storts = testInfos.OrderBy(t => t.CostTime);
            var index = 1;
            foreach (var info in storts)
            {
                Console.WriteLine("第{0}名，{1}", index, info.Message);
                index++;
            }
        }
    }
}