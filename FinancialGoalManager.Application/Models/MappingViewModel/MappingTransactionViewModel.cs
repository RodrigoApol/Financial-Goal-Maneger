using FinancialGoalManager.Application.Models.ViewModels;
using FinancialGoalManeger.Core.Entities;

namespace FinancialGoalManager.Application.Models.MappingViewModel;

public static class MappingTransactionViewModel
{
    public static List<FinancialGoalTransactionViewModel> ToViewModel(
        this IEnumerable<FinancialGoalTransaction> transactions)
    {
        return transactions.Select(t =>
            new FinancialGoalTransactionViewModel(
                t.Amount,
                t.TransactionDate.ToString("dd/MM/yyyy"),
                t.TransactionType)).ToList();
    }

    public static FinancialGoalTransactionViewModel ToViewModelWithId(this FinancialGoalTransaction transaction) =>
        new FinancialGoalTransactionViewModel(
            transaction.Amount,
            transaction.TransactionDate.ToString("dd/MM/yyyy"),
            transaction.TransactionType);
}