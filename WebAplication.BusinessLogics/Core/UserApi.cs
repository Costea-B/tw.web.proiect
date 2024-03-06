using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAplication.Domains.Entities.Response;
using WebAplication.Domains.Entities.User;

namespace WebAplication.BusinessLogics.Core
{
     public class UserApi
     {
          public ULoginResp RLoginUPService(ULoginData data)
          {

               return new ULoginResp { IsSuccess = false };
          }
     }
}
