using FluentAutomation;
using System;
using TechTalk.SpecFlow;

namespace Simple.SeleniumGmailTest
{
    [Binding]
    public class SpecFlowFeature1Steps : FluentTest
    {

        private string Your_Account = "";
        private string Your_Password = "";
        private string Your_Email = "";
        private GmailLoginPage _loginPage = null;
        private GmailLoninResultPage _loginResult = null;
        private GmailLogoutPage _logout = null;
        private GmailLogoutResultPage _logoutResult = null;
        [BeforeScenario()]
        public void Before()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Firefox);
            this._loginResult = new GmailLoninResultPage(this);
            this._logout = new GmailLogoutPage(this);
            this._logoutResult = new GmailLogoutResultPage(this);
        }

        [Given(@"前往 (.*)")]
        public void Given前往(string url)
        {
            this._loginPage = new GmailLoginPage(this, url);
            this._loginPage.Go();
        }

        [When(@"輸入帳號、密碼，然後按下登入")]
        public void Given輸入帳號密碼按下登入()
        {
            this._loginPage.Submit(Your_Account, Your_Password);
        }


        [Then(@"驗証登入成功後的網址 (.*)")]
        public void Then驗証登入成功後的網址(string url)
        {
            this._loginResult.VerifyRedirectLink(url);
        }
        [Then(@"驗証右上角顯示登入名為 (.*)，hyper link為 (.*)")]
        public void Then驗証右上角顯示登入名為小章HyperLink為HttpsPlus_Google_ComUTabMX(string nickName, string url)
        {
            this._loginResult.VerifyHyperLink(nickName, url);
        }
        [When(@"按按下右上角的登出")]
        public void When按按下右上角的登出()
        {
            this._logout.Submit();
        }

        [Then(@"驗証Email")]
        public void Then驗証Email()
        {
            this._logoutResult.VerifyEmail(Your_Email);
        }

    }
}
