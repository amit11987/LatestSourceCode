using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Linq.Expressions;

namespace Service
{
    public interface IEntityService<T> : IService
     where T : BaseEntity
    {
        int Create(T entity);
        void Delete(T entity);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();      
        void Update(T entity);
    }
}
