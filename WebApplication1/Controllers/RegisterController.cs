using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAplication.BusinessLogics.Interface;
using WebAplication.BusinessLogics;
using WebAplication.Domains.Entities.Response;
using WebAplication.Domains.Entities.User;
using WebApplication1.Models.User;

namespace WebApplication1.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ILogin _sesion;

        public RegisterController()
        {
            var bl = new BussinesLogic();
            _sesion = bl.GetLoginBL();
        }

        // GET: Register
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(UserDataRegist obj_emp)
        {
            var URData = new URegistdata
            {
                UserName = obj_emp.UserName,
                Password = obj_emp.Password,
                Email = obj_emp.Email,
                IP = Request.UserHostAddress,
                LoginDataTime = DateTime.Now,
            };

            ULoginResp resp = _sesion.UserRegistAction(URData);


            return Redirect("/Home/Index");
        }
    }
}