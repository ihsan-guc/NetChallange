using Microsoft.EntityFrameworkCore;
using NetChallange.DAL.Abstract;
using NetChallange.Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetChallange.DAL.Concrete
{
    public class EfRepository<TEntity> : IEfRepository<TEntity> where TEntity : BaseEntity<Guid>
    {
        public NetChallangeContext context;
        private DbSet<TEntity> dbset;

        public DbSet<TEntity> Dbset
        {
            get { return dbset; }
            set { dbset = value; }
        }

        public EfRepository(NetChallangeContext _context)
        {
            context = _context;
            dbset = context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            Dbset.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Dbset.AddRange(entities);
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public TEntity GetById(Guid Id)
        {
            return Dbset.Where(p=>p.Id == Id).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetList()
        {
            return Dbset.ToList();
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return Dbset as IQueryable<TEntity>;
        }

        public void Remove(TEntity entity)
        {
            Dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Dbset.RemoveRange(entities);
        }
    }
}
