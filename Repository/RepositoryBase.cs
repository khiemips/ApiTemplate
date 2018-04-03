using Common.Entity;
using Common.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    public class RepositoryBase<T> : IRepository<T>
        where T : EntityBase
    {
        #region Contractor

        public RepositoryBase(DbContext materialRepository)
        {
            _Database = materialRepository;
        }
       
        private DbContext _Database;

        #endregion

        public T GetById(string id)
        {
            var result = _Database.Get<T>().Find(x => x.Id.Equals(id)).FirstOrDefault();

            return result;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> whereCondition)
        {
            var result = _Database.Get<T>().Find(whereCondition).ToList();
            return result;
        }

        public void Insert(T entity)
        {
            _Database.Get<T>().InsertOne(entity);
        }

        public void Update(string id, T entity)
        {
            _Database.Get<T>().ReplaceOne(x => x.Id.Equals(id), entity);
        }

        public void Delete(string id)
        {
            _Database.Get<T>().DeleteOne(x => x.Id.Equals(id));
        }


        public IEnumerable<T> GetAll()
        {
            var result = _Database.Get<T>().Find(x => true).ToList();

            return result;
        }

        public long Count(Expression<Func<T, bool>> whereCondition)
        {
            var result = _Database.Get<T>().Count(whereCondition);

            return result;
        }

        public long Count()
        {
            var result = _Database.Get<T>().Count(x => true);

            return result;
        }

    }
}
