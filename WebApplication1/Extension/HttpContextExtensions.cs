using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAplication.Domains.Entities.User;

namespace WebApplication1.Extension
{
     public static class HttpContextExtensions
     {
          public static User GetMySessionObject(this HttpContext current)
          {
               return (User)current?.Session["__SessionObject"];
          }

          public static void SetMySessionObject(this HttpContext current, User profile)
          {
               current.Session.Add("__SessionObject", profile);
          }
     }
}