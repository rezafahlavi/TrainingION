using BusinessService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Xml.Linq;
using TP.Models;
using TrainingDomainModel;

namespace TP.Controllers
{
    public class UserController : Controller
    {
        
        public ActionResult Index()
        {
            User user = new User()
            {
                UserName = "Ezz",
                IsActive = true,
                IsVerified = true,
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
                ModifiedBy = 1,
                ModifiedDate = DateTime.Now

            };

            UserService service = new UserService();
            //service.Get();
            service.Insert(user);
            service.Save();

            //test komen
            return View();
            //return View(service.Get());
        }
    }
}