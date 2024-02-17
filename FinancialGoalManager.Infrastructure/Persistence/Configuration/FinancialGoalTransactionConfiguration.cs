using FinancialGoalManeger.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialGoalManager.Infrastructure.Persistence.Configuration;

public class FinancialGoalTransactionConfiguration : IEntityTypeConfiguration<FinancialGoalTransaction>
{
    public void Configure(EntityTypeBuilder<FinancialGoalTransaction> builder)
    {
        builder
            .HasKey(f => f.Id);
    }
}