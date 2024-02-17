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
        var transactions = await _service.GetAll();

        return Ok(transactions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var transaction = await _service.GetById(id);

        return Ok(transaction);
    }
 }