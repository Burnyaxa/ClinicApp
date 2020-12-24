using DAL.Entities.Entity;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity<int>
    {
        private bool _disposed = false;
        private DbContext _context;
        private DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public TEntity FirstOrDefault(int id, string includeProperties = "")
        {
            return GetAllIncluding(includeProperties).FirstOrDefault(entity => entity.Id == id);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, string includeProperties = "")
        {
            return await GetAllIncluding(includeProperties).FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity> FirstOrDefaultAsync(int id, string includeProperties = "")
        {
            return await GetAllIncluding(includeProperties).FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public IEnumerable<TEntity> GetAll(string includeProperties = "")
        {
            return GetAllIncluding(includeProperties).ToList();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, string includeProperties = "")
        {
            return GetAllIncluding(includeProperties).Where(predicate).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(string includeProperties = "")
        {
            return await GetAllIncluding(includeProperties).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, string includeProperties = "")
        {
            return await GetAllIncluding(includeProperties).Where(predicate).ToListAsync();
        }

        public IQueryable<TEntity> GetAllIncluding(string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public IQueryable<TEntity> GetAllQueryable()
        {
            return GetAllIncluding();
        }

        public TEntity GetById(int id, string includeProperties = "")
        {
            var entity = FirstOrDefault(id, includeProperties);
            return entity;
        }

        public async Task<TEntity> GetByIdAsync(int id, string includeProperties = "")
        {
            var entity = await FirstOrDefaultAsync(id, includeProperties);
            return entity;
        }

        public TEntity Insert(TEntity entity)
        {
            var result = _dbSet.Add(entity).Entity;
            return result;
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate, string includeProperties = "")
        {
            return GetAllIncluding(includeProperties).Single(predicate);
        }

        public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate, string includeProperties = "")
        {
            return await GetAllIncluding(includeProperties).SingleAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate, string includeProperties = "")
        {
            return GetAllIncluding(includeProperties).FirstOrDefault(predicate);
        }
    }
}
