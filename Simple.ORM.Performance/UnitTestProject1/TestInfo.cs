using Simple.ORM.Performance;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class TestInfo
    {
        private Func<IFlowDataAccess> _func = null;

        private string _functionName = null;

        public int RowCount { get; set; }

        public int RunTimes { get; set; }

        public double CostTime { get; set; }

        public string Message { get; set; }

        public TestInfo(Func<IFlowDataAccess> func, string functionName)
        {
            this._func = func;
            this._functionName = functionName;
        }

        public TimeSpan Run(int times)
        {
            var watch = Stopwatch.StartNew();
            while (times-- > 0)
            {
                var dao = this._func();
                this.RowCount += dao.RowCount;
                this.RunTimes++;
            }
            watch.Stop();
            this.CostTime = watch.Elapsed.TotalMilliseconds;
            this.Message = String.Format("執行 {0} 測試，共花費：{1} ms，共執行 {2} 次，取得筆數：{3}", this._functionName, this.CostTime,
                this.RunTimes, this.RowCount);
            //Console.WriteLine(this.Message);

            return watch.Elapsed;
        }
    }
}