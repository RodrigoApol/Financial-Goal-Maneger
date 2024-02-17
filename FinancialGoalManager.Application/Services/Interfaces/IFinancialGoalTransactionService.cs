using FinancialGoalManager.Application.Models.ViewModels;

namespace FinancialGoalManager.Application.Services.Interfaces;

public interface IFinancialGoalTransactionService
{
    Task<List<FinancialGoalTransactionViewModel>> GetAll();
    Task<FinancialGoalTransactionViewModel> GetById(Guid id);
}