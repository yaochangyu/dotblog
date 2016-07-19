using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Simple.Practice.MvcKendoUI.BasicGrid.Models.EntityModel;
using Simple.Practice.MvcKendoUI.BasicGrid.Models.ViewModel;

namespace Simple.Practice.MvcKendoUI.BasicGrid.Content
{
    public class MemberController : Controller
    {
        private readonly TestDbContext _dbDbContext;

        public MemberController()
        {
            if (_dbDbContext == null)
            {
                _dbDbContext = new TestDbContext();
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Members_Read([DataSourceRequest] DataSourceRequest request)
        {
            var members = _dbDbContext.Members.AsNoTracking();
            var result = members.ToDataSourceResult(request,
                                                    c => new MemberViewModel
                                                         {
                                                             FirstName = c.FirstName,
                                                             LastName = c.LastName
                                                         });
            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Members_Create([DataSourceRequest] DataSourceRequest request, 
            MemberViewModel member)
        {
            if (ModelState.IsValid)
            {
                var entity = new Member
                             {
                                 FirstName = member.FirstName,
                                 LastName = member.LastName
                             };

                _dbDbContext.Members.Add(entity);
                _dbDbContext.SaveChanges();
                member.Id = entity.Id;
            }

            return Json(new[] {member}.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Members_Update([DataSourceRequest] DataSourceRequest request, MemberViewModel member)
        {
            if (ModelState.IsValid)
            {
                var entity = new Member
                             {
                                 FirstName = member.FirstName,
                                 LastName = member.LastName
                             };

                _dbDbContext.Members.Attach(entity);
                _dbDbContext.Entry(entity).State = EntityState.Modified;
                _dbDbContext.SaveChanges();
            }

            return Json(new[] {member}.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Members_Destroy([DataSourceRequest] DataSourceRequest request, MemberViewModel member)
        {
            if (ModelState.IsValid)
            {
                var entity = new Member
                             {
                                 Id = member.Id,
                                 FirstName = member.FirstName,
                                 LastName = member.LastName
                             };

                _dbDbContext.Members.Attach(entity);
                _dbDbContext.Members.Remove(entity);
                _dbDbContext.SaveChanges();
            }

            return Json(new[] {member}.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        protected override void Dispose(bool disposing)
        {
            _dbDbContext.Dispose();
            base.Dispose(disposing);
        }
    }
}