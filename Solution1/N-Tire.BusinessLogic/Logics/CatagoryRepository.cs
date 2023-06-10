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
    public class CatagoryRepository: GenericRepository<Catagory>, ICatagoryRepository 
    {
        private readonly DbContext _database;
        public CatagoryRepository(DbContext database):base(database)
        {
            _database = database;

        }
        public override async Task<List<Catagory>> GetAll()
        {
            return await _context.Catagories.Include(x=>x.Products).ToListAsync();
        }
        public MyDataBaseDbContext _context { get => _database as MyDataBaseDbContext; }
    }
}
