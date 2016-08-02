using System.Linq;
using FluentAssertions;
using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.OAuthServer.Models;

namespace Simple.OAuthServer.Test
{
    [TestClass]
    public class UserManagerUnitTest
    {
        public string Password { get; set; } = "Pass@w0rd1";
        public string UserName { get; set; } = "test";

        public string Email { get; set; } = "test@aa.cc";

        [TestCleanup]
        public void After()
        {
            RestoreDB();
        }

        [TestInitialize]
        public void Before()
        {
            RestoreDB();
        }

        [TestMethod]
        public void UserManager_AddUser()
        {
            var dbContext = new ApplicationDbContext();
            var userModel = new ApplicationIdentityUser
            {
                UserName = UserName,
                Email = Email
            };

            var password = Password;

            var userStore = new ApplicationUserStore(dbContext);
            var userManager = new ApplicationUserManager(userStore);

            var result = userManager.Create(userModel, password);
            result.Succeeded.Should().Be(IdentityResult.Success.Succeeded);
        }

        [TestMethod]
        public void UserStore_AddUser()
        {
            //arrange
            var dbContext = new ApplicationDbContext();
            var userModel = new ApplicationIdentityUser
            {
                UserName = "test",
                Email = "test@test.com"
            };

            var userStore = new ApplicationUserStore(dbContext);

            //act
            var task = userStore.CreateAsync(userModel);
            task.ContinueWith(p =>
                              {
                                  if (task.IsCompleted)
                                  {
                                      //assert
                                  }
                              });
        }

        private void RestoreDB()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var findUsers = dbContext.Users.Where(p => p.UserName == UserName).ToList();
                foreach (var user in findUsers)
                {
                    dbContext.Users.Remove(user);
                }
                dbContext.SaveChanges();
            }
        }
    }
}