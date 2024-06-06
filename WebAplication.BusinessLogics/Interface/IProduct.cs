using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAplication.Domains.Entities.Response;
using WebAplication.Domains.Entities.User;

namespace WebAplication.BusinessLogics.Interface
{
     public interface IProduct
     {
          List<Product> GetProduct();
          Product SerchProductbyid(string id);
          Respt RegistNewPRoduct(Product product);
          void DeletProductById(string productId);
     }
}
