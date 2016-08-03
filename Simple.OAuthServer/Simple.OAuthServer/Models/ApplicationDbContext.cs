﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Simple.OAuthServer.Models
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationIdentityUser>
    {
        public ApplicationDbContext() : 
            base("DefaultConnection")
        {
        }
    }
}