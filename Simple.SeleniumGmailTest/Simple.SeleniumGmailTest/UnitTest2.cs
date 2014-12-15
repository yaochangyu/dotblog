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
        private string Your_NickName = "+小章";

        public UnitTest2()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Firefox);
        }

        [TestMethod]
        public void TestMethod1()
        {
            I.Open(this._baseUrl)
                .Enter(Your_Account).In("#Email")
                .Enter(Your_Password).In("#Passwd")
                .Click("#signIn");

            I.Wait(1);
            I.Assert.Url(this._redirectUrl);
            I.Assert.Text(Your_NickName).In(string.Format(s_linkContainer, this._personLink));
            I.Click("span.gb_6.gbii");

            //logout
            I.Click("#gb_71");

            I.Wait(1);
            I.Assert.Text(Your_Account).In("#reauthEmail");
        }
    }
}