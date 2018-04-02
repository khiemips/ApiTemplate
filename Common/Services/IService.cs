
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Common.Services
{
    public interface IService<T>
    {
        T GetById(string id);

        string Add(T entity);

        void Delete(string id);

        void Update(string id, T entity);

        IEnumerable<T> GetAll(Expression<Func<T, bool>> whereCondition);

        IEnumerable<T> GetAll();


        long Count(Expression<Func<T, bool>> whereCondition);

        long Count();
    }
}
