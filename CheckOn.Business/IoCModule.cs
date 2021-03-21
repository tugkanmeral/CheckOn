using CheckOn.Business.Abstract;
using CheckOn.DataAccess;
using CheckOn.DataAccess.Abstract;
using CheckOn.DataAccess.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOn.Business
{
    public static class IoCModule
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterSingleton<ICafeRepository, CafeRepository>();
            serviceCollection.RegisterTransient<ICafeService, CafeManager>();

            serviceCollection.AddDbContext<CheckOnDatabaseContext>(contextLifetime: ServiceLifetime.Singleton, optionsLifetime: ServiceLifetime.Singleton);
        }
    }
}
