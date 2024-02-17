using FinancialGoalManager.Application.Models.ViewModels;
using FinancialGoalManeger.Core.Entities;

namespace FinancialGoalManager.Application.Models.MappingViewModel;

public static class MappingFinancialGoalViewModel
{
    public static List<FinancialGoalViewModel> ToViewModel(this IEnumerable<FinancialGoal> financialGoals)
    {
        return financialGoals.Select(f => new FinancialGoalViewModel(
            f.Name, f.GoalAmount
        )).ToList();
    }

    public static FinancialGoalDetailsViewModel ToViwModelWithId(this FinancialGoal financialGoal) =>
        new(
            financialGoal.Name,
            financialGoal.GoalAmount,
            financialGoal.Amount,
            financialGoal.Deadline.ToString(),
            financialGoal.IdealMonthlySaving,
            financialGoal.Status,
            financialGoal.Transactions.ToViewModel());
}