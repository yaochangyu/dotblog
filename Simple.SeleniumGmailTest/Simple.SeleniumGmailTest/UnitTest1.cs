using System;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Simple.SeleniumGmailTest
{
    [TestClass]
    public class LoginGmail
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [TestInitialize]
        public void SetupTest()
        {

            driver = new FirefoxDriver();

            baseURL = "https://gmail.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public void TheLoginGmailTest()
        {
            driver.Navigate().GoToUrl(baseURL + "");
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys(your id);
            driver.FindElement(By.Id("Passwd")).Clear();
            driver.FindElement(By.Id("Passwd")).SendKeys(your password);
            driver.FindElement(By.Id("signIn")).Click();
            Assert.IsTrue(IsElementPresent(By.LinkText("+小章")));
            Assert.AreEqual("+小章", driver.FindElement(By.LinkText("+小章")).Text);
            driver.FindElement(By.CssSelector("span.gb_6.gbii")).Click();
            driver.FindElement(By.Id("gb_71")).Click();
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.Id("reauthEmail"))) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            Assert.AreEqual(your email, driver.FindElement(By.Id("reauthEmail")).Text);
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
