using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Common.Repositories
{
    public interface IRepository<T>
    {

        T GetById(string id);

        void Insert(T entity);

        void Update(string id, T entity);

        void Delete(string id);

        IEnumerable<T> GetAll(Expression<Func<T, bool>> whereCondition);

        IEnumerable<T> GetAll();

        long Count(Expression<Func<T, bool>> whereCondition);

        long Count();
    }
}
