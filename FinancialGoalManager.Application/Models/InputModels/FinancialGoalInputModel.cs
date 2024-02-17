using FiancialGoalManeger.Core.Enums;

namespace FinancialGoalManager.Application.Models.InputModels;

public class FinancialGoalInputModel
{
    public string Name { get; set; } = string.Empty;
    public decimal GoalAmount { get;  set; }
    public DateTime? Deadline { get; set; }
    public EFinancialGoalStatus Status { get; set; }
}