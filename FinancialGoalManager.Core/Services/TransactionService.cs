using FinancialGoalManeger.Core.Entities;

namespace FinancialGoalManeger.Core.Services;

public interface ITransactionService
{
    Task MakeTransaction(Guid idFinancialGoal, FinancialGoalTransaction transaction);
}