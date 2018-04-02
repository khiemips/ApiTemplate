using Microsoft.Extensions.DependencyInjection;
using Common.Entity;
using Common.Repositories;
using Common.Services;
using System;

namespace Services
{
    public class ServiceFactory
    {
        public static IService<T> Resovle<T>(IServiceProvider serviceProvider)
            where T : EntityBase
        {
            var service = serviceProvider.GetService<IService<T>>();
            return service;
        }
    }
}
