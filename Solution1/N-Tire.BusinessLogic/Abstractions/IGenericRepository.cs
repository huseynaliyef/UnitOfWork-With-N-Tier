using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.BusinessLogic.Abstractions
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        void Update(T entity);
        void Delete(T entity);

        Task Add(T entity);

        Task<List<T>> GetTableByExpresion(Expression<Func<T, bool>> expression);
    }
}
