using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        BlogManager bm = new BlogManager(new EfBlogDal());
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategoryList()
        {
            var categories = cm.CategoryGetByStatus(true);
            return PartialView(categories);
        }

        public ActionResult AdminCategoryList()
        {
            var categories = cm.CategoryList();
            return View(categories);
        }
        public ActionResult MakeActive(int id)
        {
            var category = cm.CategoryGetById(id);
            category.CategoryStatus = true;
            cm.CategoryUpdate(category);
            return RedirectToAction("AdminCategoryList");
        }
        public ActionResult MakePassive(int id)
        {
            var category = cm.CategoryGetById(id);
            category.CategoryStatus = false;
            cm.CategoryUpdate(category);
            return RedirectToAction("AdminCategoryList");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var categoryValues = cm.CategoryGetById(id);
            return View(categoryValues);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(category);
            if (result.IsValid)
            {
                category.CategoryStatus = true;
                cm.CategoryUpdate(category);
                return RedirectToAction("AdminCategoryList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            };
            return View();
        }
        [HttpGet]
        public ActionResult AddNewCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewCategory(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(category);
            if (result.IsValid)
            {
                cm.CategoryInsert(category);
                return RedirectToAction("AdminCategoryList");
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
    }
}