using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        BlogManager bm = new BlogManager(new EfBlogDal());
        AuthorManager aum = new AuthorManager(new EfAuthorDal());
        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authorInfo = bm.BlogGetById(id);
            return PartialView(authorInfo);
        }
        [AllowAnonymous]
        public PartialViewResult AuthorPopulerPosts(int id)
        {
            var authorID = bm.AuthorIdByBlogsId(id);
            var blogs = bm.BlogListGetByAuthorId(authorID);
            return PartialView(blogs);
        }

        public ActionResult AuthorList()
        {
            var authors = aum.AuthorList();
            return View(authors);
        }
        [HttpGet]
        public ActionResult AddNewAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewAuthor(Author author)
        {
            AuthorValidator authorValidator = new AuthorValidator();
            ValidationResult result = authorValidator.Validate(author);
            if (result.IsValid)
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
                        author.AuthorImage = "/image/" + fileName + fileExtension;
                    }
                }
                aum.AuthorInsert(author);
                return RedirectToAction("AuthorList");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]

        public ActionResult AuthorUpdate(int id)
        {
            var author = aum.AuthorGetById(id);
            TempData["AuthorImage"] = author.AuthorImage;
            return View(author);
        }
        [HttpPost]
        public ActionResult AuthorUpdate(Author author)
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
                        author.AuthorImage = "/image/" + fileName + fileExtension;
                    }
                    else if(TempData["AuthorImage"]!=null)
                    {
                        author.AuthorImage = TempData["AuthorImage"].ToString();
                    }
                }
                aum.AuthorUpdate(author);
                return RedirectToAction("AuthorList");

           
        }
    }
}