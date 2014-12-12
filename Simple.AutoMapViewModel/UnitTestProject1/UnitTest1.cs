using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.AutoMapViewModel;
using Simple.AutoMapViewModel.DAL;
using Simple.AutoMapViewModel.DAL.ViewModel;
using Simple.AutoMapViewModel.DAL.Model;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Migration_AccountTWViewModel_Test()
        {
            AccountTwViewModel source = new AccountTwViewModel();
            source.帳號 = "yao123";
            source.密碼 = "1234";
            Utility utility = new Utility();
            var target = utility.Migration<AccountTwViewModel, AccountTwViewModel>(source);
            Assert.AreEqual(source.帳號, target.帳號);
            Assert.AreEqual(source.密碼, target.密碼);
        }
        [TestMethod]
        public void Migration_AccountViewModel_Test()
        {
            AccountViewModel source = new AccountViewModel();
            source.UserId = "yao123";
            source.Password = "1234";
            Utility utility = new Utility();
            var target = utility.Migration<AccountViewModel, AccountViewModel>(source);
            Assert.AreEqual(source.UserId, target.UserId);
            Assert.AreEqual(source.Password, target.Password);
        }
        [TestMethod]
        public void Migration_AccountToAccountTWViewModel_Test()
        {
            Account source = new Account();
            source.UserId = "yao123";
            source.Password = "1234";
            Utility utility = new Utility();
            var target = utility.Migration<Account, AccountTwViewModel>(source);
            Assert.AreEqual(source.UserId, target.帳號);
            Assert.AreEqual(source.Password, target.密碼);
        }
        [TestMethod]
        public void Migration_AccountToAccountViewModel_Test()
        {
            Account source = new Account();
            source.UserId = "yao123";
            source.Password = "1234";
            Utility utility = new Utility();
            var target = utility.Migration<Account, AccountViewModel>(source);
            Assert.AreEqual(source.UserId, target.UserId);
            Assert.AreEqual(source.Password, target.Password);
        }


    }
}
