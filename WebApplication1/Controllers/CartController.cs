using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAplication.BusinessLogics.Interface;
using WebAplication.BusinessLogics;
using WebApplication1.Extension;

namespace WebApplication1.Controllers
{
    public class CartController : BaseController
    {
          private readonly ILogin _sesion;

          public CartController()
          {
               var bl = new BussinesLogic();
               _sesion = bl.GetLoginBL();

          }
          public ActionResult Shopping()
          {
               var user = System.Web.HttpContext.Current.GetMySessionObject();
               ViewBag.UserNam = user;
               return View();
          }
     }
}