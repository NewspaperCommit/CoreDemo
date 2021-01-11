using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NewspaperArchive.Application.Services
{


    //public interface IRepository<TContext, T>
    //where TContext : DbContext
    //where T : BaseEntity
    //{
    //    List<T> GetAll();
    //}
    public interface IRepository<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();
        IList<TEntity> GetAllMatched(Expression<Func<TEntity, bool>> match);
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity GetById(object id);
        TEntity Find(Expression<Func<TEntity, bool>> match);
        IQueryable<TEntity> GetIQueryable();
        IList<TEntity> GetAllPaged(int pageIndex, int pageSize, out int totalCount);
        int Count();
        object Insert(TEntity entity, bool saveChanges = false);
        void Delete(object id, bool saveChanges = false);
        void Delete(TEntity entity, bool saveChanges = false);
        void Update(TEntity entity, bool saveChanges = false);
        TEntity Update(TEntity entity, object key, bool saveChanges = false);
        void Commit();

        Task<IList<TEntity>> GetAllAsync();
        Task<IList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match);
        Task<TEntity> GetByIdAsync(object id);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match);
        Task<int> CountAsync();
        Task<object> InsertAsync(TEntity entity, bool saveChanges = false);
        Task DeleteAsync(object id, bool saveChanges = false);
        Task DeleteAsync(TEntity entity, bool saveChanges = false);
        Task UpdateAsync(TEntity entity, bool saveChanges = false);
        Task<TEntity> UpdateAsync(TEntity entity, object key, bool saveChanges = false);
        Task CommitAsync();
        void Dispose();
    }
}
