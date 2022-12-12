using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue.Core.Contracts
{
    public interface  IRepositoryBase<T> where T : class
    {
        Task<IList<T>> GetAll();
        Task<T> GetByCodition(Expression<Func<T,bool>> expression);

        Task Add(T entity);

        Task Update(T entity);

        Task RemoveItemByCondition(Expression<Func<T, bool>> expression);

    }
}
