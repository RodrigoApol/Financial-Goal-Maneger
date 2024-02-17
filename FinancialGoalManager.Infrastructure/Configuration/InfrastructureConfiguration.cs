using FiancialGoalManeger.Core.Repositories;
using FinancialGoalManager.Infrastructure.Persistence;
using FinancialGoalManager.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialGoalManager.Infrastructure.Configuration;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .AddContext()
            .AddRepositories();

        return services;
    }
    
    private static IServiceCollection AddContext(this IServiceCollection services)
    {
        services.AddDbContext<FinancialGoalManagerDbContext>(
            o => o.UseInMemoryDatabase("FinancialGoalManager"));

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection service)
    {
        service.AddScoped<IFinancialGoalRepository, FinancialGoalRepository>();
        service.AddScoped<IFinancialGoalTransactionRepository, FinancialGoalTransactionRepository>();

        return service;
    }
}