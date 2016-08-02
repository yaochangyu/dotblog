using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task UserStore_AddUser()
        {
            //arrange
            var dbContext = new ApplicationDbContext();
            var userModel = new ApplicationIdentityUser
            {
                UserName = UserName,
                Email =Email
            };
            var passwordHash = "AAYDYJmN/+M+AB1GABoxjU77pIOnEXftePKuD6NIbOrN8kbFBjjie8Cq9TA84RxCIA==";
            var userStore = new ApplicationUserStore(dbContext);

            //act

            await userStore.SetPasswordHashAsync(userModel, passwordHash);
            await userStore.CreateAsync(userModel);

            //assert

            using (var db=new ApplicationDbContext())
            {
               var findUser= db.Users.AsNoTracking().FirstOrDefault(p => p.UserName == UserName);
                findUser.PasswordHash.Should().Be(passwordHash);
            }
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