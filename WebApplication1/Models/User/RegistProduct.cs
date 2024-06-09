using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAplication.Domains.Entities.User;

namespace WebApplication1.Models.User
{
     public class RegistProduct
     {
          public HttpPostedFileBase ImageFile { get; set; }
          public string name { get; set; }
          public string id { get; set; }
          public float size { get; set; }
          public decimal price { get; set; }
          public int quantity { get; set; }
          public string description { get; set; }
          public Categori categori { get; set; }
          public SubCategori subCategori { get; set; }

     }
}