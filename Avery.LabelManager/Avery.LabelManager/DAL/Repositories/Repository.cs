using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Avery.LabelManager.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Avery.LabelManager.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbSet<TEntity> DbSet;
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            this.Context = context;
            DbSet = this.Context.Set<TEntity>();
        }

        public virtual ValueTask<TEntity> GetByIdAsync(object id)
        {
            return DbSet.FindAsync(id);
        }

        public virtual TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll(bool disableTracking = false)
        {
            IQueryable<TEntity> query;
            if (disableTracking)
            {
                query = DbSet.AsNoTracking().AsQueryable();
            }
            else
            {
                query = DbSet.AsQueryable();
            }
            return query;
        }

        public TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.SingleOrDefault(predicate);
        }

        public TEntity Get(int id)
        {
            return DbSet.Find(id);
        }

        public virtual DbContext GetContext()
        {
            return this.Context;
        }

        public virtual void Create(TEntity entity)
        {
            DbSet.Add(entity);
        }

        /// <summary>
        /// Does a hard delete of the entity.  Override this if you want to soft delete instead.
        /// </summary>
        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }
        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
        }


        public void RollBack()
        {
            var changedEntries = Context.ChangeTracker.Entries<TEntity>()
                .Where(x => x.State != EntityState.Unchanged)
                .ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }

        public IQueryable<TEntity> Query(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public TEntity Search(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void Add(TEntity entity)
        {
            Context.Add(entity);
        }

        public void Add(params TEntity[] entities)
        {
            entities.ToList().ForEach(x => Add(x));
        }

        public void Add(IEnumerable<TEntity> entities)
        {
            entities.ToList().ForEach(x => Add(x));
        }

        public void Delete(object id)
        {
            var entity = GetById(id);
            Delete(entity);
        }

        public void Delete(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            Context.Update(entity);
        }

        public void Update(params TEntity[] entities)
        {
            entities.ToList().ForEach(x => Update(x));
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            entities.ToList().ForEach(x => Update(x));
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false)
        {
            IQueryable<TEntity> query;
            if (disableTracking)
            {
                query = DbSet.AsNoTracking().AsQueryable();
            }
            else
            {
                query = DbSet.AsQueryable();
            }

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                query = orderBy(query);

            if (include != null)
                query = include(query);

            return query;
        }

        public Task<List<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false)
        {
            return Filter(predicate, orderBy, include, disableTracking).ToListAsync();
        }

        public virtual int Count()
        {
            return DbSet.Count();
        }
    }
}
