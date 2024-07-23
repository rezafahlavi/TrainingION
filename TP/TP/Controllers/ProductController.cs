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
    public class ProductController : Controller
    {
        // code ToDo
        public ActionResult Products()
        {
            ProductService service = new ProductService();
            IEnumerable<Product> product = service.Get().AsEnumerable();
            return View(product);
        }

        [HttpPost]
        public ActionResult Products(int ? UserID)
        {
            ProductService service = new ProductService();
            IEnumerable<Product> product = UserID > 0 ?
                service.GetBy(x => x.UserID == UserID).AsEnumerable():
                service.Get().AsEnumerable(); 
            return View(product);
        }
    }
}