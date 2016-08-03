using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Owin;

namespace Simple.OAuthServer.Test
{
    public abstract class BaseServerTest
    {
        protected TestServer Server;


        protected abstract string Password { get; set; }

        protected abstract string Username { get; set; }

        [TestInitialize]
        public void Setup()
        {
            Server = TestServer.Create(app =>
                                       {
                                           var startup = new Startup();
                                           startup.Configuration(app);
                                           app.UseErrorPage(); // See Microsoft.Owin.Diagnostics
                                           app.UseWelcomePage("/Welcome"); // See Microsoft.Owin.Diagnostics
                                           var config = new HttpConfiguration();

                                           WebApiConfig.Register(config);

                                           app.UseWebApi(config);
                                       });
        }

        [TestCleanup]
        public void Teardown()
        {
            if (Server != null)
            {
                Server.Dispose();
            }
        }

        protected virtual async Task<HttpResponseMessage> GetAsync(string uri)
        {
            return await Server.CreateRequest(uri)
                               .GetAsync();
        }

        protected virtual async Task<HttpResponseMessage> PostAsync<TModel>(string uri, TModel model)
        {
            return await Server.CreateRequest(uri)
                               .And(
                                   request =>
                                   request.Content =
                                   new ObjectContent(typeof(TModel), model, new JsonMediaTypeFormatter()))
                               .PostAsync();
        }

        protected virtual async Task<HttpResponseMessage> GetAsync(string uri, string accessToken)
        {
            return await Server.CreateRequest(uri)
                               .AddHeader("Authorization", "Bearer " + accessToken)
                               .GetAsync();
        }

        protected virtual async Task<HttpResponseMessage> PostAsync<TModel>(string uri, TModel model, string accessToken)
        {
            return await Server.CreateRequest(uri)
                               .AddHeader("Authorization", "Bearer " + accessToken)
                               .And(
                                   request =>
                                   request.Content =
                                   new ObjectContent(typeof(TModel), model, new JsonMediaTypeFormatter()))
                               .PostAsync();
        }
    }
}