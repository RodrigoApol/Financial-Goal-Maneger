using System.Collections.Immutable;
using FiancialGoalManeger.Core.Repositories;
using FinancialGoalManager.Infrastructure.Persistence;
using FinancialGoalManager.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialGoalManager.Infrastructure.Configuration;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddContext(configuration)
            .AddRepositories();

        return services;
    }
    
    private static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("FinancialGoalManager");
        
        services.AddDbContext<FinancialGoalManagerDbContext>(
            o => o.UseSqlServer(connectionString));

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection service)
    {
        service.AddScoped<IFinancialGoalRepository, FinancialGoalRepository>();
        service.AddScoped<IFinancialGoalTransactionRepository, FinancialGoalTransactionRepository>();

        return service;
    }
}