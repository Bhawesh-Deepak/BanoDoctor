using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BanoDoctor.Admin.UI.Service
{
    public interface IRepository<TEntity> where TEntity:class
    {
        Task<IList<TEntity>> GetList(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] navigationProperties);
        Task<TEntity> GetSingle(Func<TEntity, bool> where);
        Task<bool> AddEnttities(params TEntity[] items);
        Task<bool> Update(TEntity item);
        Task<bool> Delete(TEntity item);
        Task<bool> AddEntity(TEntity model);
    }
}
