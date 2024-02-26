namespace FinancialGoalManager.Application.Models.ViewModels;

public class FinancialGoalTransactionViewModel
{
    public FinancialGoalTransactionViewModel(decimal amount, string transactionDate, string transactionType)
    {
        Amount = amount;
        TransactionDate = transactionDate;
        TransactionType = transactionType;
    }

    public decimal Amount { get;  set; }
    public string TransactionDate { get; set; }
    public string TransactionType { get; set; }
}