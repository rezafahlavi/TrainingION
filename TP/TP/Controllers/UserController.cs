using BusinessService;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.UI;
using System.Xml.Linq;
using TP.Models;
using TrainingDomainModel;

namespace TP.Controllers
{
    public class UserController : Controller
    {

        // code ToDo
        public ActionResult Users()
        {
            UserService service = new UserService();
            IEnumerable<User> user = service.Get().AsEnumerable();

            return View(user);
        }

        public ActionResult Detail() 
        {
            UserService service = new UserService();
            IEnumerable<User> user = service.Get().AsEnumerable();

            return View(user);
        }

        // code Training
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
            
            return View();
            //return View(service.Get());
        }
        public ActionResult update()
        {
            UserService service = new UserService();
            User user = service.GetBy(x => x.UserName == "Ezz").FirstOrDefault();
            user.UserName = "Ezazaza";

            service.Update(user);
            service.Save();

            return View();
        }

        public ActionResult delete()
        {
            UserService service = new UserService();
            User user = service.GetBy(x => x.UserName == "Ezazaza").FirstOrDefault();
            service.Delete(user);
            service.Save();

            return View();
        }
        public ActionResult UserDetail()
        {
            UserService service = new UserService();
            User user = service.GetBy(x => x.UserID == 5).FirstOrDefault();

            return View(user); 
        }

        [HttpPost]
        public ActionResult UserDetail(User user) 
        {
            UserService service = new UserService();
            service.Update(user);
            service.Save();

            return View(user);
        }

        public ActionResult List()
        {
            UserService service = new UserService();
            IEnumerable<User> user = service.Get().AsEnumerable();

            return View(user);
        }
        [HttpPost]
        public ActionResult List(IEnumerable<User> model)
        {
            UserService service = new UserService();
            for (int i = 0; i < model.Count(); i++) 
            {
                User user = model.ElementAt(i);
                User firstUser = service.GetByFirst(x => x.UserID == user.UserID);

                firstUser.UserName = user.UserName;
                service.Update(firstUser);
            }
            
            service.Save();

            return View(model);
        }



    }
}