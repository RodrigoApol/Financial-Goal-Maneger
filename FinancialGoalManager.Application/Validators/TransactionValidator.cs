using FinancialGoalManager.Application.Models.InputModels;
using FluentValidation;

namespace FinancialGoalManager.Application.Validators;

public class TransactionValidator : AbstractValidator<FinancialGoalTransactionInputModel>
{
    public TransactionValidator()
    {
        RuleFor(
                t => t.Amount)
            .NotNull()
            .GreaterThan(10)
            .WithMessage("Value minimum is $10");

        RuleFor(
                t => t.TransactionType)
            .NotNull()
            .WithMessage("Transaction Type is Required");
    }
}