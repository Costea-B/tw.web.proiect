﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAplication.Domains.Entities.User
{
     public class URegistdata
     {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string IP { get; set; }
        public DateTime LoginDataTime { get; set; }
    }
}
