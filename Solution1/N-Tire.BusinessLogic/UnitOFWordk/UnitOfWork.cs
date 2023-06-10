using N_Tier.Data.DAL;
using N_Tier.BusinessLogic.Abstractions;
using N_Tier.BusinessLogic.Logics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.BusinessLogic.UnitOFWordk
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IProductRepository _productRepository { get; private set; }

        public ICatagoryRepository _catagoryRepository { get; private set; }

        private readonly MyDataBaseDbContext _dataBase;
        public UnitOfWork(MyDataBaseDbContext dataBase)
        {
            _dataBase = dataBase;
            _productRepository = new ProductRepository(dataBase);
            _catagoryRepository = new CatagoryRepository(dataBase);
        }
        public async Task<int> Commit()
        {
            var transaction = await _dataBase.Database.BeginTransactionAsync();
            try
            {
                var result = await _dataBase.SaveChangesAsync();
                 await transaction.CommitAsync();
                return result;
            }catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return -1;
            }
        }

        public void Dispose()
        {
            _dataBase.Dispose();
        }
    }
}
