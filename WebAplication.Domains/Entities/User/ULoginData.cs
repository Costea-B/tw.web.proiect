﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAplication.Domains.Entities.User
{
     public class ULoginData
     {
          public string UserName { get; set; }
          public string Password { get; set; }
          public DateTime LoginDataTime { get; set; }
     }
}
