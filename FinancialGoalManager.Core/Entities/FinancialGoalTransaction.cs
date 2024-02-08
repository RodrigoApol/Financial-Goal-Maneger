using FiancialGoalManeger.Core.Entities.Base;
using FiancialGoalManeger.Core.Enums;

namespace FinancialGoalManeger.Core.Entities;

public class FinancialGoalTransaction : BaseEntity
{
    public FinancialGoalTransaction(decimal amount, ETransactionType transactionType)
    {
        Amount = amount;
        TransactionType = transactionType;
        TransactionDate = DateTime.Now;

        Id = new Guid();
        CreateAt = DateTime.Now;
        IsDeleted = false;
    }

    public decimal Amount { get; private set; }
    public DateTime TransactionDate { get; private set; }
    public ETransactionType TransactionType { get; private set; }
}