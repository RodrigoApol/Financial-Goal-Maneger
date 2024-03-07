namespace FinancialGoalManeger.Core.Entities.Base;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        Id = new Guid();
        CreateAt = DateTime.Now;
        IsDeleted = false;
    }

    public Guid Id { get; init; }
    public DateTime CreateAt { get; set; }
    public bool IsDeleted { get; set; }
}