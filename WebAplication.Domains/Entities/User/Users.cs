﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAplication.Domains.Entities.User
{
     public class Users
     {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime LastLogin { get; set; }
        public string LasIp { get; set; }
        public URole Level { get; set; }
    }
}
