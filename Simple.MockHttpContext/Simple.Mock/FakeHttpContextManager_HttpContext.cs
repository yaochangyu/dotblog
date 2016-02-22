using NSubstitute;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Simple.Mock
{
    public static partial class FakeHttpContextManager
    {
        public static HttpContext CreateHttpContext()
        {
            var request = new HttpRequest("", "http://google.com", "");
            var response = new HttpResponse(new StringWriter());
            HttpContext context = new HttpContext(request, response);

            return context;
        }

        public static HttpContext SetIdentity(this HttpContext httpContext, string name, bool isAuthenticated = true)
        {
            httpContext.User = new GenericPrincipal(new GenericIdentity(name), new string[0]);

            return httpContext;
        }
    }
}