using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAplication.BusinessLogics.Core;
using WebAplication.BusinessLogics.Interface;
using WebAplication.Domains.Entities.Response;
using WebAplication.Domains.Entities.User;

namespace WebAplication.BusinessLogics.AppBL
{
     public class ProductBL : UserApi, IProduct
     {

          private readonly AdminApi _adminApi;
          public ProductBL() : this(new AdminApi()) { }

          // Constructor cu parametru
          public ProductBL(AdminApi adminApi)
          {
               _adminApi = adminApi;
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
               return _adminApi.NewProduct(product);
          }

          public void DeletProductById(string productId)
          {
               _adminApi.DeleteProduct(productId);
          }
     } 
}
