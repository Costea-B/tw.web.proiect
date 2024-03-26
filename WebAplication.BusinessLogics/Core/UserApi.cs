using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAplication.BusinessLogics.DBModel.Seed;
using WebAplication.Domain.Entities.User;
using WebAplication.Domains.Entities.Response;
using WebAplication.Domains.Entities.User;

namespace WebAplication.BusinessLogics.Core
{
     public class UserApi
     {
          public ULoginResp RLoginUPService(ULoginData data)
          {
               UDbTable user;

              
               

               return new ULoginResp { IsSuccess = false };
          }

          public ULoginResp RRegistUPService(URegistdata data)
          {

               var newUser = new UDbTable
               {
                    UserName = data.UserName,
                    Email = data.Email,
                    Password = data.Password
               };

               using (var db = new UserContext())
               {
                    db.Users.Add(newUser);
                    db.SaveChanges();
               }



                    return new ULoginResp { IsSuccess = false };
          }

     }
}
