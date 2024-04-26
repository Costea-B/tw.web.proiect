using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAplication.Domains.Entities.User;

namespace WebApplication1.Extension
{
     public static class HttpContextExtensions
     {
          public static Users GetMySessionObject(this HttpContext current)
          {
               return (Users)current?.Session["__SessionObject"];
          }

          public static void SetMySessionObject(this HttpContext current, Users profile)
          {
               current.Session.Add("__SessionObject", profile);
          }
     }
}