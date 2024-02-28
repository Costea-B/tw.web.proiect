using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
          public ActionResult Pages_Login()
          {
               return View();
          }
          public ActionResult Pages_Register()
          {
               return View();
          }
          public ActionResult Pages_Lock_Screen()
          {
               return View();
          }
     }
}