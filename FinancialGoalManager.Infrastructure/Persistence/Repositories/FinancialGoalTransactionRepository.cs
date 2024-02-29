using FiancialGoalManeger.Core.Repositories;
using FinancialGoalManeger.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialGoalManager.Infrastructure.Persistence.Repositories;

public class FinancialGoalTransactionRepository : IFinancialGoalTransactionRepository
{
    private readonly FinancialGoalManagerDbContext _dbContext;

    public FinancialGoalTransactionRepository(FinancialGoalManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<FinancialGoalTransaction>> GetAllAsync()
    {
        return await _dbContext
            .Transactions
            .Include(t => t.FinancialGoal)
            .ToListAsync();
    }

    public async Task AddAsync(FinancialGoalTransaction transaction)
    {
        await _dbContext.Transactions.AddAsync(transaction);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}