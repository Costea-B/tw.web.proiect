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
               return new AuthenticatorBL();
          }

     }
}
