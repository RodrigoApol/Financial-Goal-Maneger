using FiancialGoalManeger.Core.Enums;
using FinancialGoalManeger.Core.Entities.Base;

namespace FinancialGoalManeger.Core.Entities;

public class FinancialGoalTransaction : BaseEntity
{
    protected FinancialGoalTransaction()
    {
    }

    public FinancialGoalTransaction(Guid idFinancialGoal, decimal amount, ETransactionType transactionType)
    {
        IdFinancialGoal = idFinancialGoal;
        Amount = amount;
        TransactionType = transactionType;
        TransactionDate = DateTime.Now;
    }
    
    public decimal Amount { get; private set; }
    public DateTime TransactionDate { get; private set; }
    public ETransactionType TransactionType { get; private set; }
    public Guid IdFinancialGoal { get; private set; }
    public FinancialGoal FinancialGoal { get; set; }
}