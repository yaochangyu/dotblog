using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Simple.Practice.MvcKendoUI.BasicGrid.Models.EntityModel
{
    public class TestDbContext:DbContext
    {
        public DbSet<Member> Members { get; set; }
    }
}