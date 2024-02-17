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
        return await _dbContext.Transactions.ToListAsync();
    }

    public async Task<FinancialGoalTransaction?> GetByIdAsync(Guid id)
    {
        var transaction = await _dbContext
            .Transactions
            .SingleOrDefaultAsync(t => t.Id == id);

        return transaction;
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}