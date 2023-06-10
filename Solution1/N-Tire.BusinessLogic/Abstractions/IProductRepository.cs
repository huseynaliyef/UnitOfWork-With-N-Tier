using N_Tier.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.BusinessLogic.Abstractions
{
    public interface IProductRepository:IGenericRepository<Product>
    {
    }
}
