using DAL.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public abstract class Repository<TEntity> : IDisposable,
      IRepositorio<TEntity> where TEntity : class
    {
        TasksEntities ctx = new TasksEntities();
        private DbContextTransaction _transaction;

        //Desabilitados por motivos de perfomance
        //public IQueryable<TEntity> GetAll()
        //{
        //    return ctx.Set<TEntity>().AsNoTracking().AsQueryable();
        //}
        //public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        //{
        //    return ctx.Set<TEntity>().AsNoTracking().Where(predicate).AsQueryable();
        //}

        //Utilizar somente para casos de Update
        public TEntity Single(params object[] key)
        {
            return ctx.Set<TEntity>().Find(key);
        }

        public void Update(TEntity obj)
        {
            ctx.Entry(obj).State = EntityState.Modified;
        }

        public void SaveContext()
        {
            ctx.SaveChanges();
        }

        public void Add(TEntity obj)
        {
            ctx.Set<TEntity>().Add(obj);
        }

        public void Delete(Func<TEntity, bool> predicate)
        {
            ctx.Set<TEntity>()
                .Where(predicate).ToList()
                .ForEach(del => ctx.Set<TEntity>().Remove(del));
        }

        public void BeginTransaction()
        {
            _transaction = ctx.Database.BeginTransaction();
        }
        public void Commit()
        {
            _transaction.Commit();
        }
        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            ctx.Dispose();
            _transaction.Dispose();
        }
    }
}
