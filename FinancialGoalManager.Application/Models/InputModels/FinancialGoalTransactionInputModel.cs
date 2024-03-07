using FiancialGoalManeger.Core.Enums;

namespace FinancialGoalManager.Application.Models.InputModels;

public class FinancialGoalTransactionInputModel
{
    public Guid IdFinancialGoal { get; set; }
    public decimal Amount { get; set; }
    public  ETransactionType TransactionType { get; set; }
}