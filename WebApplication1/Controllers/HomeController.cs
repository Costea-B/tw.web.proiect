using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebAplication.BusinessLogics.Interface;
using WebAplication.BusinessLogics;
using WebAplication.Domain.Entities.User;
using WebAplication.Domains.Entities.User;
using WebApplication1.Extension;
using WebApplication1.Models.User;

namespace WebApplication1.Controllers
{
    public class HomeController : BaseController
    {
          private readonly ILogin _sesion;

          public HomeController()
          {
               var bl = new BussinesLogic();
               _sesion = bl.GetLoginBL();

          }

          

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



               var produs = _sesion.GetProduct();

               ViewBag.Products = produs;

                  return View();

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