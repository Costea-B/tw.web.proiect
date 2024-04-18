using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.User
{
     public class RegistProduct
     {
          public HttpPostedFileBase ImageFile { get; set; }
          public string name { get; set; }
          public string id { get; set; }
          public float size { get; set; }
          public float price { get; set; }
          public int quantity { get; set; }
     }
}