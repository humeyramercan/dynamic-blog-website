using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyProject.Controllers
{

    public class AuthorUserController : Controller
    {
        // GET: AuthorUser
        AuthorManager aum = new AuthorManager(new EfAuthorDal());
        CommentManager cm = new CommentManager(new EfCommentDal());
        BlogManager bm = new BlogManager(new EfBlogDal());
        Context c = new Context();
        [HttpGet]
        public ActionResult UpdateAuthor()
        {
            var mail = (string)Session["AuthorMail"];
            var values = aum.AuthorGetValuesByMail(mail);
            TempData["AuthorImage"] = values.AuthorImage;
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateAuthor(Author author)
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
            return RedirectToAction("BlogList");
        }
        public ActionResult PublishedComments(int id)
        {
            var comments = cm.GetPublishedCommentById(id);
            if (comments.Count>0)
            {
                return View(comments);
            }
            else
            {
                
                return RedirectToAction("NoComment");
            }

            
        }
        public ActionResult NoComment()
        {
            return View();
        }
        public ActionResult BlogList()
        {
            var mail = (string)Session["AuthorMail"];
            ViewBag.AuthorName = aum.AuthorGetValuesByMail(mail).AuthorName;
            ViewBag.AuthorTitle = aum.AuthorGetValuesByMail(mail).AuthorTitle;
            ViewBag.AuthorMail = aum.AuthorGetValuesByMail(mail).AuthorMail;
            ViewBag.AuthorImage = aum.AuthorGetValuesByMail(mail).AuthorImage;
            ViewBag.AuthorAbout = aum.AuthorGetValuesByMail(mail).AuthorAbout;
            ViewBag.AuthorPhoneNumber = aum.AuthorGetValuesByMail(mail).AuthorPhoneNumber;
            ViewBag.AboutShort = aum.AuthorGetValuesByMail(mail).AboutShort;
        
            var authorID = aum.AuthorGetValuesByMail(mail).AuthorID;
            ViewBag.AuthorID = authorID;
            var blogs = bm.BlogListGetByAuthorId(authorID);
            
        
            return View(blogs);
        }

        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            var blog = bm.BlogGetById(id);
            TempData["BlogCoverImage"] = blog.BlogCoverImage;
            List<SelectListItem> categories = (from x in c.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }
                                        ).ToList();
            ViewBag.categories = categories;
            List<SelectListItem> authors = (from x in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString()
                                            }
                                           ).ToList();
            ViewBag.authors = authors;
            
            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog blog)
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
                    blog.BlogCoverImage = "/image/" + fileName + fileExtension;

                }
                else if(TempData["BlogCoverImage"] !=null)
                {
                    blog.BlogCoverImage = TempData["BlogCoverImage"].ToString();
                }


            }
            blog.BlogDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.BlogStatus = true;
            bm.BlogUpdate(blog);
            return RedirectToAction("BlogList");
        }
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            List<SelectListItem> categories = (from x in c.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }
                                             ).ToList();
            ViewBag.categories = categories;
            var mail = (string)Session["AuthorMail"];
            var authorID = aum.AuthorGetValuesByMail(mail).AuthorID;
            ViewBag.authorID = authorID;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog blog)
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
                    blog.BlogCoverImage = "/image/" + fileName + fileExtension;
                }
            }
            blog.BlogDate = DateTime.Parse(DateTime.Now.ToShortDateString()); 
            blog.BlogStatus = true;
                bm.BlogInsert(blog);
                return RedirectToAction("BlogList");     

        }
        public ActionResult DeleteBlog(int id)
        {
            var blog = bm.BlogGetById(id);
            blog.BlogStatus = false;
            bm.BlogDelete(blog);
            return RedirectToAction("BlogList");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin", "Login");
        }
    }
}