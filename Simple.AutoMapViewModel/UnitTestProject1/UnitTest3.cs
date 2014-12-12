using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.AutoMapViewModel;
using Simple.AutoMapViewModel.DAL.Model;
using Simple.AutoMapViewModel.DAL.ViewModel;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void AutoMapper_Account_AccountTwViewModel_Test()
        {
            Account account = new Account();
            account.UserId = "yao123";
            account.Password = "1234";
            Mapper.Initialize(x => x.AddProfile<AccountMapperProfile>());
            var actual = Mapper.Map<AccountTwViewModel>(account);
            Assert.AreEqual(account.UserId, actual.帳號);
            Assert.AreEqual(account.Password, actual.密碼);
        }
        [TestMethod]
        public void AutoMapper_Accounts_AccountTwViewModels_Test()
        {
            List<Account> accounts = new List<Account>();
            accounts.Add(new Account() { UserId = "yao123", Password = "1234" });
            accounts.Add(new Account() { UserId = "yes123", Password = "1234" });

            Mapper.Initialize(x => x.AddProfile<AccountMapperProfile>());
            var actual = Mapper.Map<List<AccountTwViewModel>>(accounts);
            Assert.AreEqual(accounts[0].UserId, actual[0].帳號);
            Assert.AreEqual(accounts[0].Password, actual[0].密碼);
        }
        [TestMethod]
        public void AutoMapper_AccountTwViewModel_Account_Test()
        {
            AccountTwViewModel viewModel = new AccountTwViewModel();
            viewModel.帳號 = "yao123";
            viewModel.密碼 = "1234";
            Mapper.Initialize(x => x.AddProfile<AccountMapperProfile>());
            var actual = Mapper.Map<AccountTwViewModel, Account>(viewModel);
            Assert.AreEqual(viewModel.帳號, actual.UserId);
            Assert.AreEqual(viewModel.密碼, actual.Password);
        }

        [TestMethod]
        public void AutoMapper_AccountTwViewModels_Accounts_Test()
        {
            List<AccountTwViewModel> viewModels = new List<AccountTwViewModel>();
            viewModels.Add(new AccountTwViewModel() { 帳號 = "yao123", 密碼 = "1234" });
            viewModels.Add(new AccountTwViewModel() { 帳號 = "yes123", 密碼 = "1234" });

            Mapper.Initialize(x => x.AddProfile<AccountMapperProfile>());
            var actual = Mapper.Map<List<Account>>(viewModels);
            Assert.AreEqual(viewModels[0].帳號, actual[0].UserId);
            Assert.AreEqual(viewModels[0].密碼, actual[0].Password);
        }
    }
}
