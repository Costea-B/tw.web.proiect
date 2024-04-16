using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAplication.Domains.Entities.User;

namespace WebApplication1.Models.User
{
     public class ProductData
     {
          public string Username { get; set; }
          public List<string> Products { get; set; }
          public string SingleProduct { get; set; }
     }
}