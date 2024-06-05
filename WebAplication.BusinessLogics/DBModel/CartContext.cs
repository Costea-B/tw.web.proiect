using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAplication.Domains.Entities.User;

namespace WebAplication.BusinessLogics.DBModel
{
    public class CartContext : DbContext
    {
        public CartContext() :
            base("name = WebAplication")
        {
        }

        public virtual DbSet<CartDb> Cart { get; set; }

    }
}
