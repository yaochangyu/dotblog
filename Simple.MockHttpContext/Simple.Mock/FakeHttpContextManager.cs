using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Simple.Mock
{
    public static class FakeHttpContextManager
    {
        public static HttpContextBase CreateHttpContext()
        {
            var context = Substitute.For<HttpContextBase>();
            var request = Substitute.For<HttpRequestBase>();
            var response = Substitute.For<HttpResponseBase>();
            var sessionState = Substitute.For<HttpSessionStateBase>();
            var serverUtility = Substitute.For<HttpServerUtilityBase>();

            context.Request.Returns(request);
            context.Response.Returns(response);
            context.Session.Returns(sessionState);
            context.Server.Returns(serverUtility);

            return context;
        }

        public static HttpContextBase SetIdentity(this HttpContextBase httpContext, string name, bool isAuthenticated = true)
        {
            var principal = Substitute.For<IPrincipal>();
            var identity = Substitute.For<IIdentity>();
            principal.Identity.Returns(identity);
            httpContext.User.Returns(principal);

            identity.Name.Returns(name);
            identity.IsAuthenticated.Returns(isAuthenticated);

            return httpContext;
        }
    }
}