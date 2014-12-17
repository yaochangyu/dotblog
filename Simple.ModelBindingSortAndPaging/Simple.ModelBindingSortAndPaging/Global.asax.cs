using AutoMapper;
using Simple.ModelBindingSortAndPaging.Models;
using System;
using System.Data.Entity;

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