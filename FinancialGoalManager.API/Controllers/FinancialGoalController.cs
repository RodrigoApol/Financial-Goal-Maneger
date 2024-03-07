using FinancialGoalManager.Application.Models.InputModels;
using FinancialGoalManager.Application.Services.Interfaces;
using FinancialGoalManager.Infrastructure.Persistence;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace FinancialGoalManager.API.Controllers;

[ApiController]
[Route("api/financialGoal")]
public class FinancialGoalController : ControllerBase
{
    private readonly IFinancialGoalService _service;
    private readonly IValidator<FinancialGoalInputModel> _validator;

    public FinancialGoalController(IFinancialGoalService service, IValidator<FinancialGoalInputModel> validator)
    {
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var financialsGoals = await _service.GetAll();

        return Ok(financialsGoals);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var financialGoal = await _service.GetById(id);

        if (financialGoal is null)
        {
            return BadRequest();
        }

        return Ok(financialGoal);
    }
    
    [HttpGet("idealMonthlySaving/{id}")]
    public async Task<IActionResult> GetIdealMonthlySavingValue(Guid id)
    {
        var value = await _service.GetIdealMonthlySaving(id);

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> Post(FinancialGoalInputModel input)
    {
        var result = await _validator.ValidateAsync(input);

        if (!result.IsValid)
        {
            foreach (var error in result.Errors)
            {
                result.AddToModelState(ModelState);   
            }
            
        }
        
        var financialGoalId = await _service.CreateFinancialGoal(input);

        return CreatedAtAction(
            nameof(GetById),
            new { id = financialGoalId },
            input);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(FinancialGoalInputModel input, Guid id)
    {
        await _service.UpdateFinancialGoal(input, id);

        return NoContent();
    }

    [HttpPut("paused/{id}")]
    public async Task<IActionResult> Paused(Guid id)
    {
        await _service.Paused(id);

        return NoContent();
    }
    
    [HttpPut("canceled/{id}")]
    public async Task<IActionResult> Canceled(Guid id)
    {
        await _service.Canceled(id);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteFinancialGoal(id);

        return NoContent();
    }
}