using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAplication.BusinessLogics.DBModel.Seed
{
    class UserContext : DbContext
    {
        public UserContext() :
            base("name = WebAplication")
        {
        }
        public virtual DbSet<UDbTable> Users { get; set; }
    }
}
