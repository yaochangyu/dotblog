using FluentAssertions;
using FluentAssertions.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace UnitTestProject1
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        public class Product
        {
            public string Remark { get; set; }
            public decimal Price { get; set; }

            public string Name { get; set; }

            public int ID { get; set; }
        }

        [Given(@"Product資料表應有以下資料")]
        public void GivenProduct資料表應有以下資料(Table table)
        {
            var products = table.CreateSet<Product>();
            ScenarioContext.Current.Add("products", products);
        }

        [Then(@"使用table\.Row\.Select我預期應得到以下資料")]
        public void Then使用Table_Row_Select我預期應得到以下資料(Table table)
        {
            var products = ScenarioContext.Current.Get<IEnumerable<Product>>("products");
            var expected = table.Rows.Select(r =>
            new
            {
                ID = Convert.ToInt32(r["ID"]),
                Name = r["Name"],
                Price = Convert.ToDecimal(r["Price"])
            });

            expected.ShouldAllBeEquivalentTo(products);
        }

        [Then(@"我預期應得到以下資料")]
        public void Then我預期應得到以下資料(Table table)
        {
            var products = ScenarioContext.Current.Get<IEnumerable<Product>>("products");
            table.CompareToSet(products);
        }

        [Then(@"使用匿名型別我預期應得到以下資料")]
        public void Then使用匿名型別我預期應得到以下資料(Table table)
        {
            var actuals = ScenarioContext.Current.Get<IEnumerable<Product>>("products");

            var expecteds = table.CreateSet<Product>();

            var anonymousExpected1s = expecteds.Select(p => new { Name = p.Name, Price = p.Price });
            var anonymousExpected2s = expecteds.Select(p => new { ID = p.ID, Name = p.Name, Price = p.Price, Remark = p.Remark });

            anonymousExpected1s.ShouldAllBeEquivalentTo(actuals);
            anonymousExpected1s.ShouldAllBeEquivalentTo(anonymousExpected2s);
        }
    }
}