﻿using System;
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

        public ICurrentUser CurrentUser { get; set; }

        [WebMethod]
        public string HelloWorld()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return "Hello, " + HttpContext.Current.User.Identity.Name;
            }
            return "No authentication";
        }

        [WebMethod]
        public string HelloWorld1()
        {
            if (this.CurrentHttpContext.User.Identity.IsAuthenticated)
            {
                return "Hello, " + this.CurrentHttpContext.User.Identity.Name;
            }
            return "No authentication";
        }

        [WebMethod]
        public string HelloWorld2()
        {
            if (this.CurrentUser.IsAuthenticated())
            {
                return "Hello, " + this.CurrentUser.GetName();
            }
            return "No authentication";
        }
    }
}