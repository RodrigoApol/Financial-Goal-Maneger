using FinancialGoalManager.Application.Models.InputModels;
using FinancialGoalManager.Application.Models.ViewModels;

namespace FinancialGoalManager.Application.Services.Interfaces;

public interface IFinancialGoalService
{
    Task<List<FinancialGoalViewModel>> GetAll();
    Task<FinancialGoalDetailsViewModel> GetById(Guid id);
    Task<decimal> GetIdealMonthlySaving(Guid id);
    Task<Guid> CreateFinancialGoal(FinancialGoalInputModel financialGoalInput);
    Task UpdateFinancialGoal(FinancialGoalInputModel financialGoalInput, Guid id);
    Task DeleteFinancialGoal(Guid id);
    Task Paused(Guid id);
    Task Canceled(Guid id);
}