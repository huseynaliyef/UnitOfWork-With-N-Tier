using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.BusinessLogic.Models.DTO.Product
{
    public class GetProductUIDTO
    {
        public int CatagoryId { get; set; }
        public string Name { get ; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
    }
}
