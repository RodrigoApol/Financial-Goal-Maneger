using FinancialGoalManager.Application.Models.InputModels;
using FinancialGoalManager.Application.Services.Implements;
using FinancialGoalManager.Application.Services.Interfaces;
using FinancialGoalManager.Application.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialGoalManager.Application.Configuration;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service
            .AddServices()
            .AddValidators();

        return service;
    }
    
    private static IServiceCollection AddServices(this IServiceCollection service)
    {
        service.AddScoped<IFinancialGoalService, FinancialGoalService>();
        service.AddScoped<IFinancialGoalTransactionService, FinancialGoalTransactionService>();

        return service;
    }

    private static IServiceCollection AddValidators(this IServiceCollection service)
    {
        service.AddFluentValidationAutoValidation();
        service.AddTransient<IValidator<FinancialGoalInputModel>, FinancialGoalValidator>();
        service.AddTransient<IValidator<FinancialGoalTransactionInputModel>, TransactionValidator>();
        
        return service;
    }
}