using FiancialGoalManeger.Core.Enums;

namespace FinancialGoalManager.Application.Models.ViewModels;

public class FinancialGoalTransactionViewModel
{
    public FinancialGoalTransactionViewModel(decimal amount, string transactionDate, ETransactionType transactionType)
    {
        Amount = amount;
        TransactionDate = transactionDate;
        TransactionType = transactionType;
    }

    public decimal Amount { get; private set; }
    public string TransactionDate { get; private set; }
    public ETransactionType TransactionType { get; private set; }
}