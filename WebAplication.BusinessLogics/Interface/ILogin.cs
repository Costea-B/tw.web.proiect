﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebAplication.Domains.Entities.Response;
using WebAplication.Domains.Entities.User;

namespace WebAplication.BusinessLogics.Interface
{
     public interface ILogin
     {
        ULoginResp UserLoginAction(ULoginData data);
        ULoginResp UserRegistAction(URegistdata data);
        HttpCookie GenCookie(string loginCredential);
        User GetUserByCookie(string apiCookieValue);
        List<Product> GetProduct();
          Product SerchProductbyid(string id);

    }
}
