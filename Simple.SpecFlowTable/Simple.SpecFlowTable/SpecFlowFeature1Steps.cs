using System;
using System.Collections.Generic;
using System.Linq;
using Simple.Utility;
using Simple.Utility.Simple.Utility;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Simple.SpecFlowTable
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private BusinessFlowDAO _dao = null;
        [BeforeScenario()]
        public void Before()
        {
            if (this._dao == null)
            {
                this._dao = new BusinessFlowDAO();
            }

            using (NorthwindDbContext db = new NorthwindDbContext())
            {
                var query = db.Products.Where(p => p.ProductName.Contains("余小章's")).ToList();
                if (query.Any())
                {
                    db.Products.RemoveRange(query);
                    db.SaveChanges();
                }
            }
        }

        [AfterScenario()]
        public void After()
        {
            using (NorthwindDbContext db = new NorthwindDbContext())
            {
                var query = db.Products.Where(p => p.ProductName.Contains("余小章's")).ToList();
                if (query.Any())
                {
                    db.Products.RemoveRange(query);
                    db.SaveChanges();
                }
            }
        }

        [Given(@"我輸入查詢資料")]
        public void Given我輸入查詢資料(Table table)
        {
            var product = table.CreateInstance<Product>();
            ScenarioContext.Current["product"] = product;
        }

        [Given(@"預計資料應有")]
        public void Given預計資料應有(Table table)
        {
            var products = table.CreateSet<Product>();
            this._dao.Insert(products);
            this._dao.Commit();
        }

        [When(@"我按下查詢")]
        public void When我按下查詢()
        {
            var instance = ScenarioContext.Current.Get<Product>("product");
            var condition = instance.ProductName;
            var actual = this._dao.GetLikeProducts(condition);
            ScenarioContext.Current.Set(actual, "actual");
        }

        [Then(@"查詢結果應該有")]
        public void Then查詢結果應該有(Table expected)
        {
            var actual = ScenarioContext.Current.Get<IEnumerable<Product>>("actual");
            expected.CompareToSet<Product>(actual);

        }
    }
}
