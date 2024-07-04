using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using TP.Models;

namespace TP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Order order = new Order() 
            { 
                OrderID= 1,
                OrderNo= "abc"
            };

            return View(order);
        }
        
        public ActionResult index2(int? result)
        {
            Order order = new Order()
            {
                OrderNo = "index 2 testing default",
                OrderID  = result.HasValue ? result.Value : 2
            };

            Supplier supplier = new Supplier()
            {
                SupplierID = 2,
                Name = "PT Suply"
            };

            
            CombinedModels model = new CombinedModels() 
            { 
               order = order,
               supplier = supplier
            };
            

            /* pakai view bag
            ViewBag.Supplier = supplier;

            di index2 nya pakai ini
            @Html.TextBox("SupplierName", (ViewBag.Supplier as Supplier).Name)
            */

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}