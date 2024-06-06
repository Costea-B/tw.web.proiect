using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAplication.Domains.Entities.User;

namespace WebAplication.BusinessLogics.Interface
{
     public interface ICart
     {
          List<Product> GetCartProducts(string name);

          void AddProductInCartAction(string userName, string productId);
     }
}
