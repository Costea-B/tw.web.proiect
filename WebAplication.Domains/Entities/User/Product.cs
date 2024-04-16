using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAplication.Domains.Entities.User
{
     public class Product
     {
          public string name { get; set; }
          public string id { get; set; }
          public float size { get; set; }
          public float price { get; set; }
          public string img { get; set; }
          public int quantity { get; set; }
     }
}
