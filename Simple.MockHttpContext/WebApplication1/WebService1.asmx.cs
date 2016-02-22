using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        private HttpContextBase _currentHttpContext;

        public HttpContextBase CurrentHttpContext
        {
            get
            {
                if (this._currentHttpContext == null &
                    HttpContext.Current != null)
                {
                    this._currentHttpContext = new HttpContextWrapper(HttpContext.Current);
                }
                return _currentHttpContext;
            }
            set { _currentHttpContext = value; }
        }

        [WebMethod]
        public string HelloWorld()
        {
            if (this.CurrentHttpContext.User.Identity.IsAuthenticated)
            {
                return "Hello, " + this.CurrentHttpContext.User.Identity.Name;
            }
            return "No authentication";
        }
    }
}