using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    interface IRepositorio<TEntity> where TEntity : class
    {
        //Devido a motivos de performance, não utilizar nesse formato, pois sempre é criado um Select retornando TODA a entidade, mesmo forçando o select em determinado campo
        //IQueryable<TEntity> GetAll();
        //IQueryable<TEntity> Get(Func<TEntity, bool> predicate);
        //Utilizar o Single somente em casos de UPDATE
        TEntity Single(params object[] key);
        void Update(TEntity obj);
        void SaveContext();
        void Add(TEntity obj);
        void Delete(Func<TEntity, bool> predicate);

        //Transactions
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
