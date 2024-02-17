using FiancialGoalManeger.Core.Exceptions;
using FiancialGoalManeger.Core.Repositories;
using FinancialGoalManager.Application.Models.InputModels;
using FinancialGoalManager.Application.Models.MappingViewModel;
using FinancialGoalManager.Application.Models.ViewModels;
using FinancialGoalManager.Application.Services.Interfaces;
using FinancialGoalManeger.Core.Entities;

namespace FinancialGoalManager.Application.Services.Implements;

public class FinancialGoalService : IFinancialGoalService
{
    private readonly IFinancialGoalRepository _repository;

    public FinancialGoalService(IFinancialGoalRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<FinancialGoalViewModel>> GetAll()
    {
        var financialsGoals = await _repository.GetAllAsync();

        return financialsGoals.ToViewModel();
    }

    public async Task<FinancialGoalDetailsViewModel> GetById(Guid id)
    {
        var financialGoal = await _repository.GetByIdAsync(id);
        
        if (financialGoal is null)
        {
            throw new FinancialGoalNotFoundException();
        }

        return financialGoal.ToViwModelWithId();
    }

    public async Task<decimal> GetIdealMonthlySaving(Guid id)
    {
        var financialGoal = await _repository.GetByIdAsync(id);

        if (financialGoal is null || financialGoal.Deadline is null)
        {
            throw new FinancialGoalNotFoundException();
        }
        
        var value = financialGoal.IdealMonthlySavingCalc();

        return value;
    }

    public async Task<Guid> CreateFinancialGoal(FinancialGoalInputModel financialGoalInput)
    {
        var financialGoal = new FinancialGoal(
            financialGoalInput.Name, 
            financialGoalInput.GoalAmount,
            financialGoalInput.Deadline);
        
        await _repository.AddAsync(financialGoal);
        await _repository.SaveChangesAsync();
        
        return financialGoal.Id;
    }

    public async Task UpdateFinancialGoal(FinancialGoalInputModel financialGoalInput, Guid id)
    {
        var financialGoal = await _repository.GetByIdAsync(id);

        if (financialGoal is null)
        {
            throw new FinancialGoalNotFoundException();
        }
        
        financialGoal.UpdateFinancialGoal(financialGoalInput.Name, financialGoalInput.GoalAmount);

        await _repository.SaveChangesAsync();
    }

    public async Task DeleteFinancialGoal(Guid id)
    {
        var financialGoal = await _repository.GetByIdAsync(id);
        
        if (financialGoal is null)
        {
            throw new FinancialGoalNotFoundException();
        }
        
        financialGoal.DeleteFinancialGoal();

        await _repository.SaveChangesAsync();
    }

    public async Task Paused(Guid id)
    {
        var financialGoal = await _repository.GetByIdAsync(id);
        
        if (financialGoal is null)
        {
            throw new FinancialGoalNotFoundException();
        }
        
        financialGoal.FinancialGoalPaused();

        await _repository.SaveChangesAsync();
    }

    public async Task Canceled(Guid id)
    {
        var financialGoal = await _repository.GetByIdAsync(id);
        
        if (financialGoal is null)
        {
            throw new FinancialGoalNotFoundException();
        }
        
        financialGoal.FinancialGoalCanceled();

        await _repository.SaveChangesAsync();
    }
}