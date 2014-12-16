using FluentAutomation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simple.SeleniumGmailTest
{
    [TestClass]
    public class UnitTest3 : FluentTest
    {
        private string _baseUrl = "https://gmail.google.com/";
        private string _redirectUrl = "https://mail.google.com/mail/u/0/#inbox";
        private string _personLink = "https://plus.google.com/u/0/?tab=mX";
        private string Your_Account = "";
        private string Your_Password = "";
        private string Your_Email = "";

        public UnitTest3()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Firefox);
        }

        [TestMethod]
        public void TheLoginGmail_PageObject_Test()
        {
            GmailLoginPage login = new GmailLoginPage(this, this._baseUrl);
            login.Go();
            login.Submit(Your_Account, Your_Password);

            GmailLoninResultPage loginResult = new GmailLoninResultPage(this);
            loginResult.VerifyRedirectLink(this._redirectUrl);
            loginResult.VerifyHyperLink("+小章", this._personLink);

            //logout
            GmailLogoutPage logout = new GmailLogoutPage(this);
            logout.Submit();

            GmailLogoutResultPage logoutResult = new GmailLogoutResultPage(this);
            logoutResult.VerifyEmail(Your_Email);
        }
    }
}