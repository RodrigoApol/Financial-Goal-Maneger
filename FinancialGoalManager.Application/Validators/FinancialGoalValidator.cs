using FinancialGoalManager.Application.Models.InputModels;
using FluentValidation;

namespace FinancialGoalManager.Application.Validators;

public class FinancialGoalValidator : AbstractValidator<FinancialGoalInputModel>
{
    public FinancialGoalValidator()
    {
        RuleFor(
                f => f.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(30)
            .WithMessage("Name is Required");

        RuleFor(
                f => f.Deadline)
            .GreaterThanOrEqualTo(DateTime.Now)
            .WithMessage("Deadline must be greater than the current date");

        RuleFor(
                f => f.GoalAmount)
            .GreaterThanOrEqualTo(500)
            .NotNull()
            .NotEmpty()
            .WithMessage("Value minimum is $500");
    }
}