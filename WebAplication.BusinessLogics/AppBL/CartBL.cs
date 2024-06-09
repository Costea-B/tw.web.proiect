using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAplication.BusinessLogics.Core;
using WebAplication.BusinessLogics.Interface;
using WebAplication.Domains.Entities.User;

namespace WebAplication.BusinessLogics.AppBL
{
     public class CartBL : UserApi , ICart
     {
          public List<Product> GetCartProducts(string name)
          {
               return GetCartProductsAction(name);
          }

          public void AddProductInCartAction(string userName, string productId)
          {
               AddProductInCart(userName, productId);
          }

          public void DeletProductInCartAction(string username, string productId)
          {
               DeletProductInCart(username, productId);
          }
     }
}
