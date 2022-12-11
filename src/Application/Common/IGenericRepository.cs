using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public interface IGenericRepository<T> where T : class
    {
        
        Task<T> GetById(Guid id);
        Task Add(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
    }

   
}
