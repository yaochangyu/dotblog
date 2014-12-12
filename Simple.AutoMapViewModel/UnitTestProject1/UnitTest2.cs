using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.AutoMapViewModel.DAL.ViewModel;
using System;
using AutoMapper;
using Simple.AutoMapViewModel.DAL.Model;

namespace UnitTestProject1
{
    [TestClass]

    public class UnitTest2
    {
        [TestMethod]
        public void Account_AccountViewModel_Test()
        {
            Account account = new Account();
            account.UserId = "yao123";
            account.Password = "1234";
            Mapper.CreateMap<Account, AccountViewModel>();
            var actual = Mapper.Map<Account, AccountViewModel>(account);
            Assert.AreEqual(account.UserId, actual.UserId);
            Assert.AreEqual(account.Password, actual.Password);
        }
        [TestMethod]
        public void AccountViewModel_Account_Test()
        {
            AccountViewModel viewModel = new AccountViewModel();
            viewModel.UserId = "yao123";
            viewModel.Password = "1234";
            Mapper.CreateMap<AccountViewModel, Account>();
            var actual = Mapper.Map<AccountViewModel, Account>(viewModel);
            Assert.AreEqual(viewModel.UserId, actual.UserId);
            Assert.AreEqual(viewModel.Password, actual.Password);
        }

        [TestMethod]
        public void Account_AccountTwViewModel_Test()
        {
            Account account = new Account();
            account.UserId = "yao123";
            account.Password = "1234";
            Mapper.CreateMap<Account, AccountTwViewModel>()
                  .ForMember(target => target.帳號, option => option.MapFrom(source => source.UserId))
                  .ForMember(target => target.密碼, option => option.MapFrom(source => source.Password));
            var actual = Mapper.Map<Account, AccountTwViewModel>(account);
            Assert.AreEqual(account.UserId, actual.帳號);
            Assert.AreEqual(account.Password, actual.密碼);
        }


        [TestMethod]
        public void AccountTwViewModel_Account_Test()
        {
            AccountTwViewModel account = new AccountTwViewModel();
            account.帳號 = "yao123";
            account.密碼 = "1234";
            Mapper.CreateMap<AccountTwViewModel, Account>()
                .ForMember(target => target.UserId, option => option.MapFrom(source => source.帳號))
                .ForMember(target => target.Password, option => option.MapFrom(source => source.密碼));

            var actual = Mapper.Map<AccountTwViewModel, Account>(account);
            Assert.AreEqual(account.帳號, actual.UserId);
            Assert.AreEqual(account.密碼, actual.Password);
        }
    }
}