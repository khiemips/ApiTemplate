using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Common.Services;
using Services;
using Services.Materials;

namespace Repository
{
    public class ServiceRegisterModule
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            RepositoryRegisterModule.Register(services, configuration);


            services.AddSingleton(typeof(IService<>), typeof(ServiceBase<>));

            services.AddTransient<IMaterialService, MaterialService>();
        }
    }
}
