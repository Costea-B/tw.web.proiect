using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using WebAplication.Domain.Entities.User;
using WebAplication.Domains.Entities.User;

namespace WebAplication.BusinessLogics.DBModel.Seed
{
     public class ProductContext : DbContext
     {
          public ProductContext() :
              base("name = WebAplication")
          {
          }

          public virtual DbSet<ProductDb> Product { get; set; }

     }
}
