using FiancialGoalManeger.Core.Entities.Base;
using FiancialGoalManeger.Core.Enums;

namespace FinancialGoalManeger.Core.Entities;

public class FinancialGoalTransaction : BaseEntity
{
    protected FinancialGoalTransaction() {}
    
    public FinancialGoalTransaction(decimal amount, ETransactionType transactionType)
    {
        Amount = amount;
        TransactionType = transactionType;
        TransactionDate = DateTime.Now;
    }

    public decimal Amount { get; private set; }
    public DateTime TransactionDate { get; private set; }
    public ETransactionType TransactionType { get; private set; }
    public FinancialGoal FinancialGoal { get; set; }
}