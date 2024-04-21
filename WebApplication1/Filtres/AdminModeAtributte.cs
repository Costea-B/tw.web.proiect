using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAplication.BusinessLogics;
using WebAplication.BusinessLogics.Interface;
using WebAplication.Domains.Entities.User;
using WebApplication1.Extension;

namespace WebApplication1.Filtres
{
    public class AdminModeAtributte : ActionFilterAttribute
    {
        private readonly ILogin _session;

        public AdminModeAtributte()
        {
            var bl = new BussinesLogic();
            _session = bl.GetLoginBL();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var apiCookie = HttpContext.Current.Request.Cookies["X-KEY"];
            if (apiCookie != null)
            {
                var profile = _session.GetUserByCookie(apiCookie.Value);
                if (profile != null && profile.Level == URole.Admin)
                {
                    Debug.WriteLine(profile.Level);
                    HttpContext.Current.SetMySessionObject(profile);
                }
                else
                {
                    filterContext.Result = new RedirectResult("/Error/PageNotFound");
                }
            }
            else
            {
                filterContext.Result = new RedirectResult("/Login/Pages_Login");
                return;
            }

        }


    }
}
