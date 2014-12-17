using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using AutoMapper;
using Simple.ModelBindingSortAndPaging.Models;

namespace Simple.ModelBindingSortAndPaging
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Database.SetInitializer(new ThreeLayerCreateDatabaseIfNotExists());

            Mapper.Initialize(x => x.AddProfile<AccountMapperProfile>());
        }
    }
}