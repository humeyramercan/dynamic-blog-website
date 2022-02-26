using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        CommentManager cm = new CommentManager(new EfCommentDal());
        [AllowAnonymous]
        public PartialViewResult CommentList(int id)
        {
            var comments = cm.CommentListByBlogId(id);
            return PartialView(comments);
        }
       
        public ActionResult AdminPublishedCommentList()
        {
            var commentList = cm.GetCommentByStatus(true);
            return View(commentList);
        }
        public ActionResult AdminRemovedCommentList()
        {
            var commentList = cm.GetCommentByStatus(false);
            return View(commentList);
        }
        public ActionResult RemoveComment(int id)
        {
            var comment = cm.CommentGetById(id);
            comment.CommentStatus = false;
            cm.CommentDelete(comment);
            return RedirectToAction("AdminPublishedCommentList");
        }
        public ActionResult PublishComment(int id)
        {
            var comment = cm.CommentGetById(id);
            comment.CommentStatus = true;
            cm.CommentUpdate(comment);
            return RedirectToAction("AdminPublishedCommentList");
        }
    }
}