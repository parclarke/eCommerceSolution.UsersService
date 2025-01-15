using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace eCommerce.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add infrastructure services
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IUsersRepository, UsersRepository>();

        services.AddTransient<DapperDbContext>();

        return services;
    }
}

