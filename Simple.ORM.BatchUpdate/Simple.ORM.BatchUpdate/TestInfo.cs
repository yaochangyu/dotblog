using System;
using System.Diagnostics;

namespace Simple.ORM.InsertBigRow
{
    public class TestInfo
    {
        private Func<IAccess> _func = null;

        public string FunctionName { get; set; }

        public int RowCount { get; set; }

        public int RunTimes { get; set; }

        public double CostTime { get; set; }

        public string Message { get; set; }

        public TestInfo(Func<IAccess> func, string functionName)
        {
            this._func = func;
            this.FunctionName = functionName;
        }

        public void Run(int times)
        {
            Console.WriteLine("執行 {0} 測試：", this.FunctionName);

            while (times-- > 0)
            {
                var watch = Stopwatch.StartNew();
                var dao = this._func();
                watch.Stop();

                this.RunTimes++;
                this.RowCount += dao.RowCount;
                this.CostTime += watch.Elapsed.TotalMilliseconds;

                var msg = string.Format("第 {0} 次執行 {1} 測試，花費：{2} ms，成功筆數：{3}",
                    this.RunTimes.ToString("000"),
                    this.FunctionName,
                    watch.Elapsed.TotalMilliseconds.ToString("000.0000"),
                    dao.RowCount);
                Console.WriteLine(msg);
            }
            this.Message = String.Format("執行 {0} 測試，共花費：{1} ms，共執行 {2} 次，總成功筆數：{3}", this.FunctionName, this.CostTime,
                this.RunTimes, this.RowCount);
            //Console.WriteLine(this.Message);

            //return watch.Elapsed;
        }
    }
}