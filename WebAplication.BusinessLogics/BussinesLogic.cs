using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAplication.BusinessLogics.AppBL;
using WebAplication.BusinessLogics.Interface;

namespace WebAplication.BusinessLogics
{
     public class BussinesLogic
     {
          public ILogin GetLoginBL()
          {    
               return new SesionBL();
          }
          public IProduct GetProductBL()
          {
               return new ProductBL();
          }
          public IUser GetUserBL()
          {
               return new UserBL();
          }
          public ICart GetCartBL()
          {
               return new CartBL();
          }

     }
}
