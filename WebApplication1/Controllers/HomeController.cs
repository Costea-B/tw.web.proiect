using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebAplication.Domain.Entities.User;
using WebAplication.Domains.Entities.User;
using WebApplication1.Extension;
using WebApplication1.Models.User;

namespace WebApplication1.Controllers
{
    public class HomeController : BaseController
    {
          ProductData u = new ProductData
          {
               Products = new List<string> { "Product #1", "Product #2", "Product #3", "Product #4" }
          };

          // GET: Home
          public ActionResult Index()
        {
            SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return Redirect("/Login/Pages_Login");
            }
            var user = System.Web.HttpContext.Current.GetMySessionObject();
               ViewBag.UserNam = user;

               ProductData u = new ProductData
               {
                    Products = new List<string> { "Product #1", "Product #2", "Product #3", "Product #4" }
               };
               return View(u);        
               
          }
          public ActionResult Product()
          {
               var product = Request.QueryString["p"];
               var user = System.Web.HttpContext.Current.GetMySessionObject();
               ProductData u = new ProductData();
               u.Username = "Customer";
               u.SingleProduct = product;               
               ViewBag.UserNam = user;

               return View(u);
          }

          [HttpPost]
          public ActionResult Product(string btn)
          {
               return RedirectToAction("Product", "Home", new { @p = btn });
          }

          public ActionResult Dashboard2()
          {
               SessionStatus();
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
               {
                    return Redirect("/Login/Pages_Login");
               }
               var user = System.Web.HttpContext.Current.GetMySessionObject();
               ViewBag.UserNam = user;
               if (user.Level != URole.Admin) return Redirect("/Login/Pages_Login");
               
               return View();
          }

        
     }
}