﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAplication.Domains.Entities.Response;
using WebAplication.Domains.Entities.User;

namespace WebAplication.BusinessLogics.Interface
{
     public interface ILogin
     {
          ULoginResp UserLoginAction(ULoginData data);
     }
}
