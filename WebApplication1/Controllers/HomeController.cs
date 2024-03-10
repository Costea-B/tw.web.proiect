using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.User;

namespace WebApplication1.Controllers
{
     public class HomeController : Controller
     {
          // GET: Home
          public ActionResult Index()
          {
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