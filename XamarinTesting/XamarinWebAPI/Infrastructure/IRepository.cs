using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace XamarinWebAPI.Infrastructure
{
    interface IRepository<TEntity>
    {
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(int id);
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity,bool>> predicate);
        Task<IEnumerable<TEntity>> GetAll();

    }
}
