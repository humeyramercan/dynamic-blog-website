using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
  
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        CommentManager com = new CommentManager(new EfCommentDal());
        BlogManager bm = new BlogManager(new EfBlogDal());
        Context c = new Context();
        
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult FeaturedPost()
        {
            //1.post
            var postTitle1 = bm.GetLastBlogTitleByCategory(1);
            var postImage1 = bm.GetLastBlogImageByCategory(1);
            var postDate1 = bm.GetLastBlogDateByCategory(1);
            var blogID1 = bm.GetLastBlogIDByCategory(1);
            ViewBag.postTitle1 = postTitle1;
            ViewBag.postImage1 = postImage1;
            ViewBag.postDate1 = postDate1;
            ViewBag.blogID1 = blogID1;

            //2.post
            var postTitle2 = bm.GetLastBlogTitleByCategory(2);
            var postImage2 = bm.GetLastBlogImageByCategory(2);
            var postDate2 = bm.GetLastBlogDateByCategory(2);
            var blogID2 = bm.GetLastBlogIDByCategory(2);
            ViewBag.postTitle2 = postTitle2;
            ViewBag.postImage2 = postImage2;
            ViewBag.postDate2 = postDate2;
            ViewBag.blogID2 = blogID2;
            //3.post
            var postTitle3 = bm.GetLastBlogTitleByCategory(3);
            var postImage3 = bm.GetLastBlogImageByCategory(3);
            var postDate3 = bm.GetLastBlogDateByCategory(3);
            var blogID3 = bm.GetLastBlogIDByCategory(3);
            ViewBag.postTitle3 = postTitle3;
            ViewBag.postImage3 = postImage3;
            ViewBag.postDate3 = postDate3;
            ViewBag.blogID3 = blogID3;
            //4.post
            var postTitle4 = bm.GetLastBlogTitleByCategory(4);
            var postImage4 = bm.GetLastBlogImageByCategory(4);
            var postDate4 = bm.GetLastBlogDateByCategory(4);
            var blogID4 = bm.GetLastBlogIDByCategory(4);
            ViewBag.postTitle4 = postTitle4;
            ViewBag.postImage4 = postImage4;
            ViewBag.postDate4 = postDate4;
            ViewBag.blogID4 = blogID4;
            //5.post
            var postTitle5 = bm.GetLastBlogTitleByCategory(5);
            var postImage5 = bm.GetLastBlogImageByCategory(5);
            var postDate5 = bm.GetLastBlogDateByCategory(5);
            var blogID5 = bm.GetLastBlogIDByCategory(5);
            ViewBag.postTitle5 = postTitle5;
            ViewBag.postImage5 = postImage5;
            ViewBag.postDate5 = postDate5;
            ViewBag.blogID5 = blogID5;

            return PartialView();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult BlogDetails(int id)
        {
            ViewBag.id = id;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult BlogDetails(Comment comment)
        {
            CommentValidator commentValidator = new CommentValidator();
            ValidationResult result = commentValidator.Validate(comment);
            if (result.IsValid)
            {
                comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                comment.CommentStatus = true;
                com.CommentInsert(comment);
                return RedirectToAction("BlogDetails");
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
        [AllowAnonymous]
        public PartialViewResult BlogContent(int id)
        {
            var blogDetail = bm.BlogGetById(id);
            return PartialView(blogDetail);
        }
        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var blogDetail = bm.BlogGetById(id);
            return PartialView(blogDetail);

        }
        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            ViewBag.categoryName = cm.CategoryGetById(id).CategoryName;
            ViewBag.categoryDescription = cm.CategoryGetById(id).CategoryDescription;
            var blogsByCategory = bm.GetBlogsByStatusandCategory(id,true);
            if (blogsByCategory.Count == 0)
                ViewBag.blogControl = "noBlog";

            return View(blogsByCategory);
        }
        [AllowAnonymous]
        public PartialViewResult BlogList(int page=1)
        {
            var blogs = bm.GetBlogsByStatus(true).ToPagedList(page,6);
            return PartialView(blogs);
        }
      
        public PartialViewResult OtherFeaturedPost()
        {
            return PartialView();
        }
        
        public ActionResult AdminBlogList()
        {
            var categories = cm.CategoryGetByStatus(true);
            return View(categories);
        }

        public ActionResult AdminBlogListByCategory(int id)
        {
            var blog = bm.GetBlogsByStatusandCategory(id, true);
            if (blog.Count == 0)
            {
                ViewBag.blogControl = "noBlog";
            }
            return View(blog);
        }
        public ActionResult AdminRemovedBlogListByCategory(int id)
        {
            var blog = bm.GetBlogsByStatusandCategory(id, false);
            if (blog.Count == 0)
            {
                ViewBag.blogControl = "noBlog";
            }
            return View(blog);
        }
        public ActionResult AdminRemovedBlogList()
        {
            var categories = cm.CategoryGetByStatus(true);
            return View(categories);
            
        }
        public ActionResult MakeBlogActive(int id)
        {
            var blog = bm.BlogGetById(id);
            blog.BlogStatus = true;
            bm.BlogUpdate(blog);
            return RedirectToAction("AdminRemovedBlogList");
        }
        //[Authorize(Roles ="A")]

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
            List<SelectListItem> authors = (from x in c.Authors.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.AuthorName,
                                                   Value = x.AuthorID.ToString()
                                               }
                                           ).ToList();
            ViewBag.authors = authors;
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
            blog.BlogDate= DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.BlogStatus = true;
            bm.BlogInsert(blog);
            return RedirectToAction("AdminBlogList");

        }
        public ActionResult DeleteBlog(int id)
        {
            var blog = bm.BlogGetById(id);
            blog.BlogStatus = false;
            bm.BlogDelete(blog);
            return RedirectToAction("AdminBlogList");
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
                else if(TempData["BlogImage"]!=null)
                {
                    blog.BlogCoverImage = TempData["BlogCoverImage"].ToString();
                }
               

            }
            blog.BlogDate = DateTime.Parse(DateTime.Now.ToShortDateString()); 
            blog.BlogStatus = true;
            bm.BlogUpdate(blog);
            return RedirectToAction("AdminBlogList");

        }

        public ActionResult GetCommentByBlog(int id)
        {
            var commentList = com.CommentListByBlogId(id);
            return View(commentList);
        }
    }
}