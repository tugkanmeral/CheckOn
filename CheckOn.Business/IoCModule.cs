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
            serviceCollection.RegisterTransient<ICafeRepository, CafeRepository>();
            serviceCollection.RegisterScoped<ICafeService, CafeManager>();

            serviceCollection.RegisterTransient<IUserRepository, UserRepository>();
            serviceCollection.RegisterScoped<IUserAccountService, UserAccountManager>();

            serviceCollection.RegisterScoped<IAuthenticationService, AuthenticationManager>();

            serviceCollection.RegisterSingleton<ICryptoService, CryptoManager>();

            serviceCollection.AddDbContext<CheckOnDatabaseContext>(contextLifetime: ServiceLifetime.Transient, optionsLifetime: ServiceLifetime.Transient);
        }
    }
}
