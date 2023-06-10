using Microsoft.EntityFrameworkCore;
using N_Tier.Data.DAL;
using N_Tier.BusinessLogic.Abstractions;
using N_Tier.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.BusinessLogic.Logics
{
    public class ProductRepository: GenericRepository<Product>, IProductRepository
    {
        private readonly DbContext _dataBase;
        public ProductRepository(DbContext dataBase):base(dataBase) 
        {
            _dataBase = dataBase;
        }

        public MyDataBaseDbContext _context { get => _dataBase as MyDataBaseDbContext; }
    }
}
