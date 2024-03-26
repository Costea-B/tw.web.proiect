using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using WebAplication.Domain.Entities.User;

namespace WebAplication.BusinessLogics.DBModel.Seed
{
      public class UserContext : DbContext
    {
        public UserContext() :
            base("name = databaseName")
        {
        }
        public virtual DbSet<UDbTable> Users { get; set; }
    }
}
