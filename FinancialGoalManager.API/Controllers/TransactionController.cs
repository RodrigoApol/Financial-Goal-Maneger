using FinancialGoalManager.Application.Models.InputModels;
using FinancialGoalManager.Application.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FinancialGoalManager.API.Controllers;

[ApiController]
[Route("api/transactions")]
public class TransactionController : ControllerBase
{
    private readonly IFinancialGoalTransactionService _service;
    private readonly IValidator<FinancialGoalTransactionInputModel> _validator;

    public TransactionController(IFinancialGoalTransactionService service, IValidator<FinancialGoalTransactionInputModel> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
            var transactions = await _service.GetAll();

            return Ok(transactions);
    }

    [HttpPost]
    public async Task<IActionResult> Post(FinancialGoalTransactionInputModel inputModel)
    {
        var result = await _validator.ValidateAsync(inputModel);

        if (!result.IsValid)
        {
            foreach (var error in result.Errors)
            {
                var message = error.ErrorMessage;
            }
        }
        
        await _service.CreateTransaction(inputModel);

        return Created();
    }
 }