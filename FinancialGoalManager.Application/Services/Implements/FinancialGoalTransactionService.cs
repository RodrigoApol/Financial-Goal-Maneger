using FiancialGoalManeger.Core.Exceptions;
using FiancialGoalManeger.Core.Repositories;
using FinancialGoalManager.Application.Models.MappingViewModel;
using FinancialGoalManager.Application.Models.ViewModels;
using FinancialGoalManager.Application.Services.Interfaces;

namespace FinancialGoalManager.Application.Services.Implements;

public class FinancialGoalTransactionService : IFinancialGoalTransactionService
{
    private readonly IFinancialGoalTransactionRepository _repository;

    public FinancialGoalTransactionService(IFinancialGoalTransactionRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<FinancialGoalTransactionViewModel>> GetAll()
    {
        var transactions = await _repository.GetAllAsync();

        return transactions.ToViewModel();
    }

    public async Task<FinancialGoalTransactionViewModel> GetById(Guid id)
    {
        var transaction = await _repository.GetByIdAsync(id);

        if (transaction is null)
        {
            throw new TransactionNotFoundException();
        }

        return transaction.ToViewModelWithId();
    }
}