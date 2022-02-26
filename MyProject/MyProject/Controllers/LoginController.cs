using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller

    {
        AuthorManager aum = new AuthorManager(new EfAuthorDal());
        AdminManager adm = new AdminManager(new EfAdminDal());
        // GET: Login
        [HttpGet]
        public ActionResult AuthorLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthorLogin(Author author)
        {
            var authorValues = aum.AuthorGetFirstOrDefaultLogin(author);
            if (authorValues != null)
            {
                FormsAuthentication.SetAuthCookie(authorValues.AuthorMail, false);
                Session["AuthorMail"] = authorValues.AuthorMail.ToString();
                return RedirectToAction("BlogList", "AuthorUser");
            }
            else
            {
                return RedirectToAction("AuthorLogin");
            }
            
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var adminValues = adm.AdminGetFirstOrDefaultLogin(admin);
            if (adminValues != null)
            {
                FormsAuthentication.SetAuthCookie(adminValues.UserName, false);
                Session["UserName"] = adminValues.UserName.ToString();
                return RedirectToAction("AdminBlogList", "Blog");
            }
            else
            {
                return RedirectToAction("AdminLogin");
            }

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AdminLogin", "Login");
        }
    }
}