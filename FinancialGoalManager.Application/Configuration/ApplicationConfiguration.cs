using FinancialGoalManager.Application.Services.Implements;
using FinancialGoalManager.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialGoalManager.Application.Configuration;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddServices();

        return service;
    }
    
    private static IServiceCollection AddServices(this IServiceCollection service)
    {
        service.AddScoped<IFinancialGoalService, FinancialGoalService>();
        service.AddScoped<IFinancialGoalTransactionService, FinancialGoalTransactionService>();

        return service;
    }
}