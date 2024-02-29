using FiancialGoalManeger.Core.Enums;
using FiancialGoalManeger.Core.Exceptions;
using FiancialGoalManeger.Core.Repositories;
using FinancialGoalManager.Application.Models.InputModels;
using FinancialGoalManager.Application.Models.MappingViewModel;
using FinancialGoalManager.Application.Models.ViewModels;
using FinancialGoalManager.Application.Services.Interfaces;
using FinancialGoalManeger.Core.Entities;

namespace FinancialGoalManager.Application.Services.Implements;

public class FinancialGoalTransactionService : IFinancialGoalTransactionService
{
    private readonly IFinancialGoalTransactionRepository _repository;
    private readonly IFinancialGoalRepository _fgRepository;

    public FinancialGoalTransactionService(IFinancialGoalTransactionRepository repository, IFinancialGoalRepository fgRepository)
    {
        _repository = repository;
        _fgRepository = fgRepository;
    }
    
    public async Task<List<FinancialGoalTransactionViewModel>> GetAll()
    {
        var transactions = await _repository.GetAllAsync();

        return transactions.ToViewModel();
    }

    public async Task CreateTransaction(Guid idFinancialGoal, FinancialGoalTransactionInputModel inputModel)
    {
        var financialGoal = await _fgRepository.GetByIdAsync(idFinancialGoal);

        if (financialGoal is null)
        {
            throw new FinancialGoalNotFoundException();
        }

        if (financialGoal.Status == EFinancialGoalStatus.InProgress)
        {
            var transaction = new FinancialGoalTransaction(
                inputModel.Amount,
                inputModel.TransactionType);
            
            switch (transaction.TransactionType)
            {
                case ETransactionType.Deposit:
                    financialGoal.IsDeposit(transaction.Amount);
                    financialGoal.FinancialGoalCompleted();
                    break;
                case ETransactionType.Withdraw:
                    financialGoal.IsWithdraw(transaction.Amount);
                    break;
                default: throw new ArgumentException("Error");
            }
            
            await _repository.AddAsync(transaction);
        }

        if (financialGoal.Status is EFinancialGoalStatus.Canceled or EFinancialGoalStatus.Paused
            or EFinancialGoalStatus.Completed)
        {
            throw new ArgumentException("Transaction not valid");
        }
        
    }
}