using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAplication.Domains.Entities.User
{
    public class CartDb
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public ICollection<Produs> Produc { get; set; }    
        public bool CompletOrder { get; set; }

    }
}
