using System.Collections.Generic;
using WebAplication.Domains.Entities.User;

namespace WebApplication1.Models.User
{
     public class GlobalModel
     {
          public string Username { get; set; }
          public string Email { get; set; }
          public List<Product> Products { get; set; }
          public Product Product { get; set;  }
          public List<Users> Users { get; set; }
          public URole Level { get; set; }
          public decimal TotalPrice { get; set; }

    }
}