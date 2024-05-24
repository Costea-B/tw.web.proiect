using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAplication.Domains.Entities.User
{
     public class Product
     {
          public int id { get; set; }
          public string idsneakers { get; set; }
          public string name { get; set; }
          public float size { get; set; }
          public float price { get; set; }
          public string img { get; set; }
          public int quantity { get; set; }
          public string description { get; set; }
          public Categori categori { get; set; }
          public SubCategori subCategori { get; set; }
     }
}
