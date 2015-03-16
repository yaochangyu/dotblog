using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class TestInfo
    {
        private Action _action = null;
        private string _functionName = null;

        public int RunCount { get; set; }

        public TestInfo(Action action, string functionName)
        {
            this._action = action;
            this._functionName = functionName;
        }

        public TimeSpan Run(int times)
        {
            var watch = Stopwatch.StartNew();
            while (times-- > 0)
            {
                this._action();
                //var member = this._func();
                //_members.Add(member);
                RunCount++;
            }
            watch.Stop();
            Console.WriteLine(String.Format("執行 {0} 測試，共花費 {1} ms", this._functionName, watch.Elapsed.TotalMilliseconds));

            return watch.Elapsed;
        }
    }
}