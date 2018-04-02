using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Common.Repositories;
using Common.Entity;

namespace Repository
{
    public class RepositoryFactory
    {
        public static IRepository<T> Resovle<T>(IServiceProvider serviceProvider) 
            where T : EntityBase
        {
            var repository = serviceProvider.GetService<IRepository<T>>();
            return repository;
        }
    }
}
