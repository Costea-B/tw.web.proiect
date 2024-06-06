using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAplication.Domains.Entities.User;

namespace WebAplication.BusinessLogics.Interface
{
     public interface IUser
     {
          void DeletUserById(int UserId);
          List<Users> GetUser();

     }
}
