using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        // GET: About
        AboutManager abm = new AboutManager(new EfAboutDal());
        AuthorManager autm = new AuthorManager(new EfAuthorDal());
        
        public ActionResult Index()
        {
            var aboutContent = abm.AboutList();
            return View(aboutContent);
        }
        public PartialViewResult MeetTheTeam()
        {
            var authors = autm.AuthorList();
            return PartialView(authors);
        }
        public PartialViewResult Footer()
        {
            var about = abm.AboutList();
            return PartialView(about);
        }

        [HttpGet]
        public ActionResult UpdateAbout()
        {
            var aboutValues = abm.AboutList();
            foreach (var item in aboutValues)
            {
                TempData["AboutImage1"] = item.AboutImage1;
                TempData["AboutImage2"] = item.AboutImage2;
            }


            return View(aboutValues);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {

            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    string fileExtension = Path.GetExtension(Request.Files[0].FileName);
                    string path = "~/image/" + fileName + fileExtension;
                    Request.Files[0].SaveAs(Server.MapPath(path));
                    about.AboutImage1 = "/image/" + fileName + fileExtension;

                }
                else if(TempData["AboutImage1"]!=null)
                {
                    about.AboutImage1 = TempData["AboutImage1"].ToString();
                }
                var file2 = Request.Files[1];
                if (file2 != null && file2.ContentLength > 0)
                {
                    string fileName2 = Path.GetFileName(Request.Files[1].FileName);
                    string fileExtension2 = Path.GetExtension(Request.Files[1].FileName);
                    string path2 = "~/image/" + fileName2 + fileExtension2;
                    Request.Files[1].SaveAs(Server.MapPath(path2));
                    about.AboutImage2 = "/image/" + fileName2 + fileExtension2;

                }
                else if(TempData["AboutImage2"]!=null)
                {

                    about.AboutImage2 = TempData["AboutImage2"].ToString();
                }

            }
            abm.AboutUpdate(about);
            return RedirectToAction("UpdateAbout");
        }
    }
}