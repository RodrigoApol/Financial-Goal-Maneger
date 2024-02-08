using FinancialGoalManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialGoalManager.Infrastructure.Configuration;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddContext();

        return services;
    }
    
    private static IServiceCollection AddContext(this IServiceCollection services)
    {
        services.AddDbContext<FinancialGoalManagerDbContext>(
            o => o.UseInMemoryDatabase("FinancialGoalManager"));

        return services;
    }
}