using FiancialGoalManeger.Core.Enums;

namespace FinancialGoalManager.Application.Models.ViewModels;

public class FinancialGoalDetailsViewModel
{
    public FinancialGoalDetailsViewModel(string name, decimal goalAmount, decimal amount, string? deadline, decimal? idealMonthlySaving, EFinancialGoalStatus status, List<FinancialGoalTransactionViewModel> transactions)
    {
        Name = name;
        GoalAmount = goalAmount;
        Amount = amount;
        Deadline = deadline;
        IdealMonthlySaving = idealMonthlySaving;
        Status = status;
        Transactions = transactions;
    }

    public string Name { get;  set; }
    public decimal GoalAmount { get;  set; }
    public decimal Amount { get; set; }
    public string? Deadline { get;  set; }
    public decimal? IdealMonthlySaving { get; set; }
    public EFinancialGoalStatus Status { get; set; }
    public List<FinancialGoalTransactionViewModel> Transactions { get;  set; }
}