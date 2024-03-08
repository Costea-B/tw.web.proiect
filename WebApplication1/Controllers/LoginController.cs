using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAplication.BusinessLogics;
using WebAplication.BusinessLogics.Interface;
using WebAplication.Domains.Entities.Response;
using WebAplication.Domains.Entities.User;
using WebApplication1.Models.User;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
          private readonly ILogin _sesion;

          public LoginController()
          {
               var bl = new BussinesLogic();
               _sesion = bl.GetLoginBL(); 

          }       

         

          public ActionResult Pages_Login()
        {
             return View();
        }

          public ActionResult Pages_Logins(UserData data)
          {
               var UData = new ULoginData
               {
                    UserName = data.UserName,
                    Password = data.Password,
                    LoginDataTime = DateTime.Now,
               };

               ULoginResp resp = _sesion.UserLoginAction(UData);

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
          [HttpPost]
      
          public ActionResult Pages_Login(UserData obj_emp)
          {
               string username = obj_emp.UserName;
               string password = obj_emp.Password;
               return View();
          }

     }
}