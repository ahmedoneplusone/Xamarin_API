using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace XamarinWebAPI.Infrastructure
{
    public class BaseRepository<TEntity, IDBcontext> : IRepository<TEntity>
        where TEntity : class
        where IDBcontext : DbContext
    {
        private readonly IDBcontext dBcontext;
        public BaseRepository(IDBcontext dBcontext)
        {
            this.dBcontext = dBcontext;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            await dBcontext.Set<TEntity>().AddAsync(entity);
            await dBcontext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await dBcontext.Set<TEntity>().FindAsync(id);
            dBcontext.Set<TEntity>().Remove(entity);
            await dBcontext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Get(int id)
        {
            return await dBcontext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await dBcontext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await dBcontext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            dBcontext.Entry(entity).State = EntityState.Modified;
            await dBcontext.SaveChangesAsync();
            return entity;
        }

 
    }
}
