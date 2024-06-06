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
     public class UserBL : AdminApi , IUser
     {
          public void DeletUserById(int UserId)
          {
               DeleteUser(UserId);
          }

          public List<Users> GetUser()
          {
               return SelectAllUser();
          }
     }
}
