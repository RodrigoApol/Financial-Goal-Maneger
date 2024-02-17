using FinancialGoalManeger.Core.Entities;

namespace FiancialGoalManeger.Core.Repositories;

public interface IFinancialGoalTransactionRepository
{
    Task<List<FinancialGoalTransaction>> GetAllAsync();
    Task<FinancialGoalTransaction?> GetByIdAsync(Guid id);
    Task SaveChangesAsync();
}