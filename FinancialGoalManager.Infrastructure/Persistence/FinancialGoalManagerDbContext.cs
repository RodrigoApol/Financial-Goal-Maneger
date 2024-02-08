using FinancialGoalManeger.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialGoalManager.Infrastructure.Persistence;

public class FinancialGoalManagerDbContext : DbContext
{
    public FinancialGoalManagerDbContext(DbContextOptions<FinancialGoalManagerDbContext> options) : base(options)
    {
        
    }
    public DbSet<FinancialGoal> FinancialsGoals { get; set; }
    public DbSet<FinancialGoalTransaction> Transactions { get; set; }
}