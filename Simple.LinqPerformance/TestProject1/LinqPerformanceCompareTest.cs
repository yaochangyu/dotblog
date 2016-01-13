using System;
using System.Collections.Generic;
using LinqPerformance;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    /// <summary>
    ///This is a test class for LinqPerformanceCompareTest and is intended
    ///to contain all LinqPerformanceCompareTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LinqPerformanceCompareTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        //
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class

        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //    _target = new LinqPerformanceCompare();
        //}

        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        private static LinqPerformanceCompare _target = new LinqPerformanceCompare();

        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //    if (_target == null)
        //    {
        //        _target = new LinqPerformanceCompare();
        //    }
        //}

        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        //[TestMethod()]
        //public void AnullTest()
        //{
        //    _target = new LinqPerformanceCompare();
        //}

        /// <summary>
        ///A test for GetCode1
        ///</summary>
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\test.csv", "test#csv", DataAccessMethod.Sequential), DeploymentItem("TestProject1\\test.csv"), TestMethod()]
        public void GetCode01Test()
        {
            var count = TestContext.DataRow[0].ToString();
            for (int j = 0; j < _target.Time; j++)
            {
                var boo = _target.ToFill[j];
                boo.Code = _target.GetCode1(boo.No, boo.SubNo);
            }

            //挑選三個抽樣檢查執行結果是否一致
            var expected = _target.ToFill;
            var actual = new string[] { "C183", "C436", "C560" };
            Assert.AreEqual(expected[1].Code, actual[0]);
            Assert.AreEqual(expected[10].Code, actual[1]);
            Assert.AreEqual(expected[50].Code, actual[2]);
        }

        /// <summary>
        ///A test for GetCode2
        ///</summary>
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\test.csv", "test#csv", DataAccessMethod.Sequential), DeploymentItem("TestProject1\\test.csv"), TestMethod()]
        public void GetCode02Test()
        {
            var count = TestContext.DataRow[0].ToString();
            for (int j = 0; j < _target.Time; j++)
            {
                var boo = _target.ToFill[j];
                boo.Code = _target.GetCode2(boo.No, boo.SubNo);
            }

            //挑選三個抽樣檢查執行結果是否一致
            var expected = _target.ToFill;
            var actual = new string[] { "C183", "C436", "C560" };
            Assert.AreEqual(expected[1].Code, actual[0]);
            Assert.AreEqual(expected[10].Code, actual[1]);
            Assert.AreEqual(expected[50].Code, actual[2]);
        }

        /// <summary>
        ///A test for GetCode3
        ///</summary>
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\test.csv", "test#csv", DataAccessMethod.Sequential), DeploymentItem("TestProject1\\test.csv"), TestMethod()]
        public void GetCode03Test()
        {
            var count = TestContext.DataRow[0].ToString();
            for (int j = 0; j < _target.Time; j++)
            {
                var boo = _target.ToFill[j];
                boo.Code = _target.GetCode3(boo.No, boo.SubNo);
            }

            //挑選三個抽樣檢查執行結果是否一致
            var expected = _target.ToFill;
            var actual = new string[] { "C183", "C436", "C560" };
            Assert.AreEqual(expected[1].Code, actual[0]);
            Assert.AreEqual(expected[10].Code, actual[1]);
            Assert.AreEqual(expected[50].Code, actual[2]);
        }

        /// <summary>
        ///A test for GetCode4
        ///</summary>
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\test.csv", "test#csv", DataAccessMethod.Sequential), DeploymentItem("TestProject1\\test.csv"), TestMethod()]
        public void GetCode04Test()
        {
            var count = TestContext.DataRow[0].ToString();
            for (int j = 0; j < _target.Time; j++)
            {
                var boo = _target.ToFill[j];
                boo.Code = _target.GetCode4(boo.No, boo.SubNo);
            }

            //挑選三個抽樣檢查執行結果是否一致
            var expected = _target.ToFill;
            var actual = new string[] { "C183", "C436", "C560" };
            Assert.AreEqual(expected[1].Code, actual[0]);
            Assert.AreEqual(expected[10].Code, actual[1]);
            Assert.AreEqual(expected[50].Code, actual[2]);
        }

        /// <summary>
        ///A test for GetCode5
        ///</summary>
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\test.csv", "test#csv", DataAccessMethod.Sequential), DeploymentItem("TestProject1\\test.csv"), TestMethod()]
        public void GetCode05Test()
        {
            var count = TestContext.DataRow[0].ToString();
            for (int j = 0; j < _target.Time; j++)
            {
                var boo = _target.ToFill[j];
                boo.Code = _target.GetCode5(boo.No, boo.SubNo);
            }

            //挑選三個抽樣檢查執行結果是否一致
            var expected = _target.ToFill;
            var actual = new string[] { "C183", "C436", "C560" };
            Assert.AreEqual(expected[1].Code, actual[0]);
            Assert.AreEqual(expected[10].Code, actual[1]);
            Assert.AreEqual(expected[50].Code, actual[2]);
        }

        /// <summary>
        ///A test for GetCode6
        ///</summary>
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\test.csv", "test#csv", DataAccessMethod.Sequential), DeploymentItem("TestProject1\\test.csv"), TestMethod()]
        public void GetCode06Test()
        {
            var count = TestContext.DataRow[0].ToString();
            for (int j = 0; j < _target.Time; j++)
            {
                var boo = _target.ToFill[j];
                boo.Code = _target.GetCode6(boo.No, boo.SubNo);
            }

            //挑選三個抽樣檢查執行結果是否一致
            var expected = _target.ToFill;
            var actual = new string[] { "C183", "C436", "C560" };
            Assert.AreEqual(expected[1].Code, actual[0]);
            Assert.AreEqual(expected[10].Code, actual[1]);
            Assert.AreEqual(expected[50].Code, actual[2]);
        }

        /// <summary>
        ///A test for GetCode6
        ///</summary>
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\test.csv", "test#csv", DataAccessMethod.Sequential), DeploymentItem("TestProject1\\test.csv"), TestMethod()]
        public void GetCode07Test()
        {
            var count = TestContext.DataRow[0].ToString();
            for (int j = 0; j < _target.Time; j++)
            {
                var boo = _target.ToFill[j];
                boo.Code = _target.GetCode7(boo.No, boo.SubNo);
            }

            //挑選三個抽樣檢查執行結果是否一致
            var expected = _target.ToFill;
            var actual = new string[] { "C183", "C436", "C560" };
            Assert.AreEqual(expected[1].Code, actual[0]);
            Assert.AreEqual(expected[10].Code, actual[1]);
            Assert.AreEqual(expected[50].Code, actual[2]);
        }

        /// <summary>
        ///A test for GetCode6
        ///</summary>
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\test.csv", "test#csv", DataAccessMethod.Sequential), DeploymentItem("TestProject1\\test.csv"), TestMethod()]
        public void GetCode08Test()
        {
            var count = TestContext.DataRow[0].ToString();
            for (int j = 0; j < _target.Time; j++)
            {
                var boo = _target.ToFill[j];
                boo.Code = _target.GetCode8(boo.No, boo.SubNo);
            }

            //挑選三個抽樣檢查執行結果是否一致
            var expected = _target.ToFill;
            var actual = new string[] { "C183", "C436", "C560" };
            Assert.AreEqual(expected[1].Code, actual[0]);
            Assert.AreEqual(expected[10].Code, actual[1]);
            Assert.AreEqual(expected[50].Code, actual[2]);
        }

        /// <summary>
        ///A test for GetCode6
        ///</summary>
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\test.csv", "test#csv", DataAccessMethod.Sequential), DeploymentItem("TestProject1\\test.csv"), TestMethod()]
        public void GetCode09Test()
        {
            var count = TestContext.DataRow[0].ToString();
            for (int j = 0; j < _target.Time; j++)
            {
                var boo = _target.ToFill[j];
                boo.Code = _target.GetCode9(boo.No, boo.SubNo);
            }

            //挑選三個抽樣檢查執行結果是否一致
            var expected = _target.ToFill;
            var actual = new string[] { "C183", "C436", "C560" };
            Assert.AreEqual(expected[1].Code, actual[0]);
            Assert.AreEqual(expected[10].Code, actual[1]);
            Assert.AreEqual(expected[50].Code, actual[2]);
        }

        /// <summary>
        ///A test for GetCode6
        ///</summary>
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\test.csv", "test#csv", DataAccessMethod.Sequential), DeploymentItem("TestProject1\\test.csv"), TestMethod()]
        public void GetCode10Test()
        {
            var count = TestContext.DataRow[0].ToString();
            for (int j = 0; j < _target.Time; j++)
            {
                var boo = _target.ToFill[j];
                boo.Code = _target.GetCode10(boo.No, boo.SubNo);
            }

            //挑選三個抽樣檢查執行結果是否一致
            var expected = _target.ToFill;
            var actual = new string[] { "C183", "C436", "C560" };
            Assert.AreEqual(expected[1].Code, actual[0]);
            Assert.AreEqual(expected[10].Code, actual[1]);
            Assert.AreEqual(expected[50].Code, actual[2]);
        }
    }
}