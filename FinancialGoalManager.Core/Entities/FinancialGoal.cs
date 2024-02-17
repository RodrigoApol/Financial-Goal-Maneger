using FiancialGoalManeger.Core.Entities.Base;
using FiancialGoalManeger.Core.Enums;

namespace FinancialGoalManeger.Core.Entities;

public class FinancialGoal : BaseEntity
{
    protected FinancialGoal() {}
    
    public FinancialGoal(string name, decimal goalAmount, DateTime? deadline)
    {
        Name = name;
        GoalAmount = goalAmount;
        Deadline = deadline ?? null;
        Status = EFinancialGoalStatus.InProgress;

        Amount = 0;
        Id = new Guid();
        CreateAt = DateTime.Now;
        IsDeleted = false;
    }

    public string Name { get; private set; }
    public decimal GoalAmount { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime? Deadline { get; private set; }
    public decimal? IdealMonthlySaving { get; private set; }
    public EFinancialGoalStatus Status { get; private set; }
    public List<FinancialGoalTransaction> Transactions { get; private set; }

    public void UpdateFinancialGoal(string name, decimal goalAmount)
    {
        Name = name;
        GoalAmount = goalAmount;
    }
    
    public decimal IdealMonthlySavingCalc()
    {
        var goalAmount = GoalAmount;
        var deadline = Deadline.GetValueOrDefault();
        var dateNow = DateTime.Now;
        const int months = 12;
        
        var monthUntilDeadline = (
            (deadline.Year - dateNow.Year) * months) + deadline.Month - dateNow.Month;

        var value = goalAmount / monthUntilDeadline;

        IdealMonthlySaving = value;

        return IdealMonthlySaving ?? 0;
    }

    public void FinancialGoalCompleted()
    {
        if (Amount == GoalAmount)
        {
            Status = EFinancialGoalStatus.Completed;
        }
    }

    public void FinancialGoalPaused()
    {
        Status = EFinancialGoalStatus.Paused;
    }
    
    public void FinancialGoalCanceled()
    {
        Status = EFinancialGoalStatus.Canceled;
    }

    public void DeleteFinancialGoal()
    {
        IsDeleted = true;
    }
}