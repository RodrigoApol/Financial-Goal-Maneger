namespace FinancialGoalManager.Application.Models.ViewModels;

public class FinancialGoalViewModel
{
    public FinancialGoalViewModel(string name, decimal goalAmount)
    {
        Name = name;
        GoalAmount = goalAmount;
    }

    public string Name { get; set; }
    public decimal GoalAmount { get; set; }
}