namespace FiancialGoalManeger.Core.Entities.Base;

public abstract class BaseEntity
{
    public Guid Id { get; init; }
    public DateTime CreateAt { get; set; }
    public bool IsDeleted { get; set; }
}