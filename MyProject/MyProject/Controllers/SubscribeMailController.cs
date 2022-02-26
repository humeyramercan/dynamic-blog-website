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
    [AllowAnonymous]
    public class SubscribeMailController : Controller
    {
        // GET: SubscribeMail
        SubscribeMailManager sm = new SubscribeMailManager(new EfSubscribeMailDal());
      
        [HttpGet]
        public PartialViewResult AddSubscribeMail()
        {
            return PartialView();
        }   
        [HttpPost]
        public PartialViewResult AddSubscribeMail(SubscribeMail subscribeMail)
        {
            SubscribeMailValidator subscribeMailValidator = new SubscribeMailValidator();
            ValidationResult results = subscribeMailValidator.Validate(subscribeMail);
            if (results.IsValid)
            {
                sm.SubscribeMailInsert(subscribeMail);
                return PartialView();
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return PartialView();
        }


    }
}
