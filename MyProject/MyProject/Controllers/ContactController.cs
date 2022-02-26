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
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
     
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult SendMessage()
        {
            if (TempData["successMessage"] != null)
            {
                ViewBag.successMessage = TempData["successMessage"];
            }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult SendMessage(Contact contact)
        {
            ContactValidator contactValidator = new ContactValidator();
            ValidationResult results = contactValidator.Validate(contact);
            if (results.IsValid)
            {
                TempData["successMessage"] = "Mesajınız gönderildi.";
                var shortDate = DateTime.Now.ToString("dd-MMM-yyyy");
                 contact.ContactDate = Convert.ToDateTime(shortDate);
                cm.ContactInsert(contact);
                return RedirectToAction("SendMessage");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult InBox()
        {
            var contacts = cm.ContactList();
            return View(contacts);
        }

        public ActionResult MessageDetalis(int id)
        {
            var values = cm.ContactGetById(id);
            return View(values);
        }
    }
}