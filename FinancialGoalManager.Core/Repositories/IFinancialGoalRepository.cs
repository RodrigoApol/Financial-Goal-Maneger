using FinancialGoalManeger.Core.Entities;

namespace FiancialGoalManeger.Core.Repositories;

public interface IFinancialGoalRepository
{
    Task<List<FinancialGoal>> GetAllAsync();
    Task<FinancialGoal?> GetByIdAsync(Guid id);
    Task AddAsync(FinancialGoal financialGoal);
    Task SaveChangesAsync();
}