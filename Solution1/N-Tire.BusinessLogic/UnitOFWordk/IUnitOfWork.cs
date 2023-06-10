using N_Tier.BusinessLogic.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.BusinessLogic.UnitOFWordk
{
    public interface IUnitOfWork
    {
        IProductRepository _productRepository { get; }
        ICatagoryRepository _catagoryRepository { get; }
        Task<int> Commit();
    }
}
