using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.OAuthServer.Models;

namespace Simple.OAuthServer.Test
{
    [TestClass]
    public class AccountApiControllerTest : BaseServerTest
    {
        private const string s_baseUri = "/api/account";
        protected override string Password { get; set; } = "Pass@w0rd1";
        protected override string Username { get; set; } = "test@aa.cc";

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
            AppSetting.UserLockoutEnabledByDefault = true;
            AppSetting.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            AppSetting.MaxFailedAccessAttemptsBeforeLockout = 3;
        }

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
        public async Task Login_Bearer_Test()
        {
            await RegisterAsync();
            var token = await LoginAsync();
            token.AccessToken.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task Login_Fail_3_Lockout_3Test()
        {
            await RegisterAsync();

            Password = "Pass@w0rd2~";
            var token1 = await LoginAsync();
            token1.ErrorDescription.Should()
                  .Be("Invalid credentials. You have 2 more attempt(s) before your account gets locked out.");
            Password = "Pass@w0rd2~";
            var token2 = await LoginAsync();
            token2.ErrorDescription.Should()
                  .Be("Invalid credentials. You have 1 more attempt(s) before your account gets locked out.");

            Password = "Pass@w0rd2~";
            var token3 = await LoginAsync();
            token3.ErrorDescription.Should()
                  .Be("Your account has been locked out for 5 minutes due to multiple failed login attempts.");
        }

        private async Task<Token> LoginAsync()
        {
            var form = new Dictionary<string, string>
            {
                {"grant_type", "password"},
                {"username", Username},
                {"password", Password}
            };
            var content = new FormUrlEncodedContent(form);
            var response = await Server.HttpClient.PostAsync("/oauth/token", content);

            var token = await response.Content.ReadAsAsync<Token>(new[] {new JsonMediaTypeFormatter()});
            return token;
        }

        [TestMethod]
        public async Task Register_Test()
        {
            var response = await RegisterAsync();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        private async Task<HttpResponseMessage> RegisterAsync()
        {
            var model = new RegisterBindingModel
            {
                Email = Username,
                Password = Password,
                ConfirmPassword = Password
            };

            var response = await PostAsync(s_baseUri + "/Register", model);
            return response;
        }

        private void RestoreDB()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var findUsers = dbContext.Users.Where(p => p.Email == Username).ToList();

                foreach (var user in findUsers)
                {
                    dbContext.Users.Remove(user);
                }

                dbContext.SaveChanges();
            }
        }
    }
}