using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using FluentAutomation;

namespace Simple.SeleniumGmailTest
{
    [TestClass]
    public class UnitTest2 : FluentAutomation.FluentTest
    {
        private string _baseUrl = "https://gmail.google.com/";
        private const string s_linkContainer = "a[href='{0}']";
        private string _redirectUrl = "https://mail.google.com/mail/u/0/#inbox";
        private string _personLink = "https://plus.google.com/u/0/?tab=mX";
        private string Your_Account = "";
        private string Your_Password = "";
        private string Your_Email = "";

        public UnitTest2()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Firefox,
                                        SeleniumWebDriver.Browser.Chrome
                                        );
        }

        [TestMethod]
        public void TheLoginGmail_FluentAPI_Test()
        {
            I.Open(this._baseUrl)
                .Enter(Your_Account).In("#Email")
                .Enter(Your_Password).In("#Passwd")
                .Click("#signIn");

            I.Wait(2);
            I.Assert.Url(this._redirectUrl);
            I.Assert.Text("+小章").In(string.Format(s_linkContainer, this._personLink));
            I.Click("span.gb_6.gbii");

            //logout
            I.Click("#gb_71");

            I.Wait(2);
            I.Assert.Text(Your_Email).In("#reauthEmail");
        }
    }
}