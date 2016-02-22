using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class CurrentUser : ICurrentUser
    {
        public string GetName()
        {
            return HttpContext.Current.User.Identity.Name;
        }

        public bool IsAuthenticated()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
    }
}