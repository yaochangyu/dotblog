using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Simple.OAuthServer.Models
{
    public class ApplicationUserManager: UserManager<ApplicationIdentityUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationIdentityUser> store) : 
            base(store)
        {
        }
    }
}