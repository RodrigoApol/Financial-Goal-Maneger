using FinancialGoalManager.Application.Models.InputModels;
using FinancialGoalManager.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinancialGoalManager.API.Controllers;

[ApiController]
[Route("api/transactions")]
public class TransactionController : ControllerBase
{
    private readonly IFinancialGoalTransactionService _service;

    public TransactionController(IFinancialGoalTransactionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var transactions = await _service.GetAll();

            return Ok(transactions);
        }
        catch 
        {
            return BadRequest();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Guid id, FinancialGoalTransactionInputModel inputModel)
    {
        await _service.CreateTransaction(id, inputModel);

        return Created();
    }
 }