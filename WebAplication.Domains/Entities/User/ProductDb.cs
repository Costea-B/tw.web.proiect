using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAplication.Domains.Entities.User
{
     public class ProductDb
     {

          public string name { get; set; }
          public string id { get; set; }
          public float size { get; set; }
          public float price { get; set; }
          public string img { get; set; }
          public int quantity { get; set; }

     }
}
