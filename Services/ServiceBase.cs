using Common.Entity;
using Common.Repositories;
using Common.Services;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Services
{
    public class ServiceBase<T> : IService<T>
        where T : EntityBase
    {
        private IRepository<T> Repository { get; set; }

        #region Contractor

        public ServiceBase(IServiceProvider serviceProvider)
        {
            Repository = RepositoryFactory.Resovle<T>(serviceProvider);
        }
        #endregion


        public T GetById(string id)
        {
            var result = Repository.GetById(id);
            return result;

        }

        public string Add(T entity)
        {
            Repository.Insert(entity);
            return entity.Id;
        }

        public void Delete(string id)
        {
            Repository.Delete(id);
        }

        public void Update(string id, T entity)
        {
            Repository.Update(id, entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> whereCondition)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            var result = Repository.GetAll();

            return result;
        }


        public long Count(Expression<Func<T, bool>> whereCondition)
        {
            throw new NotImplementedException();
        }

        public long Count()
        {
            var result = Repository.Count();
            return result;
        }
    }
}
