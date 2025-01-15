using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using eCommerce.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace eCommerce.Core;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add infrastructure services
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddTransient<IUsersService, UsersService>();
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

        return services;
    }
}

