﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Common.Repositories;
using Repository.Materials;

namespace Repository
{
    public class RepositoryRegisterModule
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbSetting>(option =>
            {
                option.ConnectionString = configuration.GetSection("MongoDbSetting:ConnectionString").Value;
                option.Database = configuration.GetSection("MongoDbSetting:Database").Value;
            });



            services.AddTransient<MaterialRepository, MaterialRepository>();


            services.AddSingleton(typeof(IRepository<>), typeof(RepositoryBase<>));
            services.AddSingleton(typeof(IMaterialRepository<>), typeof(MaterialRepository<>));
        }
    }
}
