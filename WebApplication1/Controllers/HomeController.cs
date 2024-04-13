using System;
using System.Collections.Generic;
using System.Data.Entity;
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
               return View();
               
               
          }
        public ActionResult Dashboard2()
        {
            return View();
        }
        public ActionResult Charts()
        {
            return View();
        }
        public ActionResult Calendar()
        {
            return View();
        }
        public ActionResult Companies()
        {
            return View();
        }
        public ActionResult FileManager()
        {
            return View();
        }
        public ActionResult Tickets()
        {
            return View();
        }
        public ActionResult TeamMembers()
        {
            return View();
        }

          [HttpPost]
       public ActionResult Index(UserData obj_emp)
        {

               
               return View();
        }

          


     }
}