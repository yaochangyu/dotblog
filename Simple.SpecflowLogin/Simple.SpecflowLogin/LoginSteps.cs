using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.Utility;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Simple.SpecflowLogin
{
    [Binding]
    public class LoginSteps
    {
        private Security _security = null;

        [BeforeScenario()]
        public void Before()
        {
            this._security = new Security();
        }
        [Given(@"我輸入")]
        public void Given我輸入(Table inputTable)
        {
            var account = inputTable.CreateSet<Account>();
        }


        [When(@"我按下Login")]
        public void When我按下Login()
        {
            var userId = ScenarioContext.Current.Get<string>("userId");
            var password = ScenarioContext.Current.Get<string>("password");
            var actual = this._security.IsVerify(userId, password);
            ScenarioContext.Current.Set<bool>(actual, "actual");
        }

        [Then(@"結果應為")]
        public void Then結果應為(bool expected)
        {
            var actual = ScenarioContext.Current.Get<bool>("actual");
            Assert.AreEqual(expected, actual);
        }

        //不建議的寫法，不應該用for去驗証，而應該使用specflow
        //[Given(@"我輸入")]
        //public void Given我輸入(Table table)
        //{
        //    var accounts = table.CreateSet<Account>();
        //    ScenarioContext.Current.Set(accounts, "accounts");
        //}

        //[When(@"我按下Login")]
        //public void When我按下Login()
        //{
        //    //var accounts = ScenarioContext.Current.Get<List<Account>>("accounts");
        //    //var actual = accounts.Select(account => this._security.IsVerify(account.UserId, account.Password));
        //    //ScenarioContext.Current.Set(actual, "actual");

        //    var account = ScenarioContext.Current.Get<Account>("accounts");
        //    var actual = this._security.IsVerify(account.UserId, account.Password);
        //    ScenarioContext.Current.Set(actual, "actual");

        //}

        //[Then(@"結果應為")]
        //public void Then結果應為(Table expected)
        //{
        //    //var actuals = ScenarioContext.Current.Get<IEnumerable<bool>>("actual");
        //    //expected.CompareToSet(actuals.Select(x => new { Result = x }));
        //    var actuals = ScenarioContext.Current["actual"];
        //    //expected.CompareToSet(actuals.Select(x => new { Result = x }));
        //    var result = ((IEnumerable)ScenarioContext.Current["actual"]).Cast<bool>();

        //}
    }
}