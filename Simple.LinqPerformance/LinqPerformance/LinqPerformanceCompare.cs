using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqPerformance
{
    public class LinqPerformanceCompare
    {
        private static readonly int MAX_NO = 100;
        private int _time = 500;

        public int Time
        {
            get { return _time; }
            set { _time = value; }
        }

        private List<Boo> _pool = new List<Boo>();

        public List<Boo> Pool
        {
            get { return _pool; }
            set { _pool = value; }
        }

        private List<Boo> _shuffled;

        public List<Boo> Shuffled
        {
            get { return _shuffled; }
            set { _shuffled = value; }
        }

        private Dictionary<string, Boo> _dict;

        public Dictionary<string, Boo> Dict
        {
            get { return _dict; }
            set { _dict = value; }
        }

        private Dictionary<string, string> _strDict;

        public Dictionary<string, string> StrDict
        {
            get { return _strDict; }
            set { _strDict = value; }
        }

        private List<Boo> _toFill = new List<Boo>();

        public List<Boo> ToFill
        {
            get { return _toFill; }
            set { _toFill = value; }
        }

        public LinqPerformanceCompare()
        {
            //使用相口同亂數種子確保每次執行之測試資料相同

            Random rnd = new Random(9527); //交給你了，9527
            //建立大量物件集合
            for (int i = 0; i < MAX_NO; i++)
            {
                for (int j = 0; j < rnd.Next(500, 1000); j++)
                {
                    this.Pool.Add(new Boo()
                    {
                        No = i,
                        SubNo = j,
                        Code = "C" + rnd.Next(1000).ToString("000")
                    });
                }
            }

            //打亂排序
            this.Shuffled = this.Pool.OrderBy(o => rnd.Next()).ToList();

            //建立Dictionary
            this.Dict = this.Pool.ToDictionary(
                o => string.Format("{0}\t{1}", o.No, o.SubNo),
                o => o);

            //建立字串Dictionary
            this.StrDict = this.Pool.ToDictionary(
                o => string.Format("{0}\t{1}", o.No, o.SubNo),
                o => o.Code);

            //產生TIMES個待查對象
            for (int i = 0; i < this.Time; i++)
            {
                Boo sample = this.Pool[rnd.Next(_pool.Count)];
                this.ToFill.Add(new Boo()
                {
                    No = sample.No,
                    SubNo = sample.SubNo
                });
            }
        }

        public string GetCode1(int n, int sn)
        {
            return this.Pool.Single(o => o.No == n && o.SubNo == sn).Code;
        }

        public string GetCode2(int n, int sn)
        {
            return this.Shuffled.Single(o => o.No == n && o.SubNo == sn).Code;
        }

        public string GetCode3(int n, int sn)
        {
            return this.Dict[string.Format("{0}\t{1}", n, sn)].Code;
        }

        public string GetCode4(int n, int sn)
        {
            return this.StrDict[string.Format("{0}\t{1}", n, sn)];
        }

        public string GetCode5(int n, int sn)
        {
            return this.Pool.First(o => o.No == n && o.SubNo == sn).Code;
        }

        public string GetCode6(int n, int sn)
        {
            return this.Shuffled.First(o => o.No == n && o.SubNo == sn).Code;
        }

        public string GetCode7(int n, int sn)
        {
            return this.Pool.AsParallel().Single(o => o.No == n && o.SubNo == sn).Code;
        }

        public string GetCode8(int n, int sn)
        {
            return this.Shuffled.AsParallel().Single(o => o.No == n && o.SubNo == sn).Code;
        }

        public string GetCode9(int n, int sn)
        {
            return this.Pool.AsParallel().First(o => o.No == n && o.SubNo == sn).Code;
        }

        public string GetCode10(int n, int sn)
        {
            return this.Shuffled.AsParallel().First(o => o.No == n && o.SubNo == sn).Code;
        }
    }
}