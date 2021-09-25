using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace Avery.LabelManager.DAL.Repositories.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> Query(string sql, params object[] parameters);

        TEntity Search(params object[] keyValues);

        TEntity Single(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false);

        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false);

        Task<List<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = false);

        int Count();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);


        void Add(TEntity entity);
        void Add(params TEntity[] entities);
        void Add(IEnumerable<TEntity> entities);
        void Create(TEntity entity);

        void Delete(TEntity entity);
        void Delete(object id);
        void Delete(params TEntity[] entities);
        void Delete(IEnumerable<TEntity> entities);
        void DeleteRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void Update(params TEntity[] entities);
        void Update(IEnumerable<TEntity> entities);

        ValueTask<TEntity> GetByIdAsync(object id);
        TEntity GetById(object id);
        IQueryable<TEntity> GetAll(bool disableTracking = false);
        TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(int id);

        void RollBack();
        
    }

}
