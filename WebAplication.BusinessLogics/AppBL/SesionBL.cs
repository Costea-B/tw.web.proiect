using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using WebAplication.BusinessLogics.Core;
using WebAplication.BusinessLogics.Interface;
using WebAplication.Domains.Entities.Response;
using WebAplication.Domains.Entities.User;
using System.IO;

namespace WebAplication.BusinessLogics.AppBL
{
     public class SesionBL : UserApi, ILogin
     {
          public ULoginResp UserLoginAction(ULoginData data)
          {
               return RLoginUPService(data);
          }

          public ULoginResp UserRegistAction(URegistdata data)
          {
               return RRegistUPService(data);
          }

          public HttpCookie GenCookie(string username)
          {
               return Cookie(username);
          }
          public User GetUserByCookie(string apiCookieValue)
          {
               return GetCookie(apiCookieValue);
          }

          public List<Product> GetProduct()
          {
               return SelectAllProducts();
          }

          public Product SerchProductbyid(string id)
          {
               return SercheProduct(id);
          }

          public Respt RegistNewPRoduct(Product product)
          {
               return NewProduct(product);
          }
     }
}
