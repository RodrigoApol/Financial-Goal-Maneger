using FinancialGoalManager.Application.Models.InputModels;
using FinancialGoalManager.Application.Models.ViewModels;

namespace FinancialGoalManager.Application.Services.Interfaces;

public interface IFinancialGoalTransactionService
{
    Task<List<FinancialGoalTransactionViewModel>> GetAll();
    Task CreateTransaction(FinancialGoalTransactionInputModel inputModel);
}