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
        public async Task Register_Test()
        {
            var model = new RegisterBindingModel
            {
                Email = Username,
                Password = Password,
                ConfirmPassword = Password
            };

            var response = await PostAsync(s_baseUri + "/Register", model);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Login_Bearer_Test()
        {
            var model = new RegisterBindingModel
            {
                Email = Username,
                Password = Password,
                ConfirmPassword = Password
            };

            await PostAsync(s_baseUri + "/Register", model);

            var form = new Dictionary<string, string>
            {
                {"grant_type", "password"},
                {"username", Username},
                {"password", Password}
            };


            var content = new FormUrlEncodedContent(form);
            var response =
                Server.HttpClient.PostAsync("/oauth/token", content).Result;

            var token = response.Content.ReadAsAsync<Token>(new[] {new JsonMediaTypeFormatter()}).Result;

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            token.AccessToken.Should().NotBeNullOrEmpty();
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