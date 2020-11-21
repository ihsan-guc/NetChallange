using System;
using System.Collections.Generic;
using System.Linq;

namespace NetChallange.DAL.Abstract
{
    public interface IEfRepository<TEntity>
    {
        IQueryable<TEntity> GetQueryable();
        IEnumerable<TEntity> GetList(); 
        TEntity GetById(Guid Id);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Commit();
    }
}
