using FiancialGoalManeger.Core.Repositories;
using FinancialGoalManeger.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialGoalManager.Infrastructure.Persistence.Repositories;

public class FinancialGoalRepository : IFinancialGoalRepository
{
    private readonly FinancialGoalManagerDbContext _dbContext;

    public FinancialGoalRepository(FinancialGoalManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<FinancialGoal>> GetAllAsync()
    {
        return await _dbContext.FinancialsGoals.ToListAsync();
    }

    public async Task<FinancialGoal?> GetByIdAsync(Guid id)
    {
        var financialGoal = await _dbContext
            .FinancialsGoals
            .Include(f => f.Transactions)
            .SingleOrDefaultAsync(f => f.Id == id);

        return financialGoal;
    }

    public async Task AddAsync(FinancialGoal financialGoal)
    {
        await _dbContext.FinancialsGoals.AddAsync(financialGoal);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}