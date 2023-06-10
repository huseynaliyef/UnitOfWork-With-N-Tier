using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Data.Entities
{
    public class Catagory:BaseEntity
    {
        public Catagory()
        {
            Products = new HashSet<Product>();
        }
        public string CatagoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
