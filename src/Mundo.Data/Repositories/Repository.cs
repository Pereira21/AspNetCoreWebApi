using Microsoft.EntityFrameworkCore;
using Mundo.Business.Entities;
using Mundo.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mundo.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly MundoContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(MundoContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Add(TEntity model)
        {
            DbSet.Add(model);
            await SaveChanges();
        }

        public async Task Delete(Guid id)
        {
            DbSet.Remove(new TEntity() { Id = id });
            await SaveChanges();
        }

        public async Task Update(TEntity model)
        {
            DbSet.Update(model);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
