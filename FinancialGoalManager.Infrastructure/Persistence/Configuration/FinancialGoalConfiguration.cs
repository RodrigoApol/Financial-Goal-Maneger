using FinancialGoalManeger.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialGoalManager.Infrastructure.Persistence.Configuration;

public class FinancialGoalConfiguration : IEntityTypeConfiguration<FinancialGoal>
{
    public void Configure(EntityTypeBuilder<FinancialGoal> builder)
    {
        builder
            .HasKey(f => f.Id);

        builder
            .HasMany(f => f.Transactions)
            .WithOne(f => f.FinancialGoal)
            .HasForeignKey(f => f.IdFinancialGoal)
            .OnDelete(DeleteBehavior.Restrict);
    }
}