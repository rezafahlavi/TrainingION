using BusinessService;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.UI;
using System.Xml.Linq;
using TP.Models;
using TrainingDomainModel;

namespace TP.Controllers
{
    public class UserController : Controller
    {

        // code ToDo day 1 dan 2
        public ActionResult Users()
        {
            UserService service = new UserService();
            IEnumerable<User> user = service.Get().AsEnumerable();

            return View(user);
        }

        [HttpGet]
        public ActionResult Detail(int ? UserID) 
        {
            UserService service = new UserService();
            User user = service.GetBy(x => x.UserID == UserID).FirstOrDefault();
            ViewBag.Mode = "Edit";


            return View(user);
        }

        [HttpGet]
        public ActionResult View(int UserID)
        {
            UserService service = new UserService();
            User user = service.GetBy(x => x.UserID == UserID).FirstOrDefault();

            return View("Detail", user);
        }

        [HttpPost]
        public ActionResult Detail(User user)
        {
            UserService service = new UserService();

            if (user.UserID == 0)
            {
                service.InsertUser(user);
                service.Save();
            }
            else
            {
                user.UserDetail.UserID = user.UserID;
                service.UpdateUser(user);
                service.Save();
            }
            return RedirectToAction("Users", user);
        }

        [HttpGet]
        public ActionResult Delete(int UserID)
        {
            UserService service = new UserService();
            User user = service.GetBy(x => x.UserID == UserID).FirstOrDefault();
            service.DeleteUser(user);
            service.Save();

            return RedirectToAction("Users");
        }

        public ActionResult Products()
        {
            UserService service = new UserService();
            IEnumerable<User> user = service.Get().AsEnumerable();
            return View(); 
        }


        // code ToDo day 3

        public ActionResult AjaxUsers()
        {
            UserService service = new UserService();
            IEnumerable<User> user = service.Get().AsEnumerable();

            return View(user);
        }


        [HttpGet]
        public ActionResult AjaxDetail(int? UserID)
        {
            UserService service = new UserService();
            User user = service.GetBy(x => x.UserID == UserID).FirstOrDefault();
            ViewBag.Mode = "Edit";

            return View(user);
        }

        [HttpGet]
        public ActionResult AjaxView(int UserID)
        {
            UserService service = new UserService();
            User user = service.GetBy(x => x.UserID == UserID).FirstOrDefault();

            return View("AjaxDetail", user);
        }

        [HttpPost]
        public JsonResult AjaxDetailSave(User user)
        {
            UserService service = new UserService();
            if (user.UserID == 0)
            {
                service.InsertUser(user);
                service.Save();
            }
            else {
                user.UserDetail.UserID = user.UserID;
                service.UpdateUser(user);
                service.Save();
            }

            return Json(new { Status = "error", Message = "" });
        }


        [HttpGet]
        public ActionResult AjaxDelete(int UserID)
        {
            UserService service = new UserService();
            User user = service.GetBy(x => x.UserID == UserID).FirstOrDefault();
            service.DeleteUser(user);
            service.Save();

            return RedirectToAction("AjaxUsers");
        }

        public ActionResult AjaxProducts()
        {
            UserService service = new UserService();
            IEnumerable<User> user = service.Get().AsEnumerable();
            return View();
        }











            // code Training day 3

            public ActionResult AjaxInsert()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Save(User user)
         {
            return Json(new {Status = "error", Message = user.UserName + " " + user.UserDetail.Phone});        
        }



            // code Training day 1 dan 2
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

        public ActionResult delete2()
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