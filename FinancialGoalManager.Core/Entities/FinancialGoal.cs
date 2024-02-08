using FiancialGoalManeger.Core.Entities.Base;
using FiancialGoalManeger.Core.Enums;

namespace FinancialGoalManeger.Core.Entities;

public class FinancialGoal : BaseEntity
{
    public FinancialGoal(string name, decimal goalAmount, DateTime? deadline)
    {
        Name = name;
        GoalAmount = goalAmount;
        Deadline = deadline ?? null;
        Status = EFinancialGoalStatus.Active;

        Id = new Guid();
        CreateAt = DateTime.Now;
        IsDeleted = false;
    }

    public string Name { get; private set; }
    public decimal GoalAmount { get; private set; }
    public DateTime? Deadline { get; private set; }
    public decimal? IdealMonthlySaving { get; private set; }
    public EFinancialGoalStatus Status { get; private set; }
    public FinancialGoalTransaction Transaction { get; private set; }

    public void UpdateFinancialGoal(string name, decimal goalAmount)
    {
        Name = name;
        GoalAmount = goalAmount;
    }
}