using BlazorExpenseTracker.Server.Data;
using BlazorExpenseTracker.Server.Services;
using BlazorExpenseTracker.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorExpenseTracker.Server.Controllers
{
    [Route("api/Expenses")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _service;

        public ExpenseController(IExpenseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Expense>>> GetAllExpensesAsync()
        {
            var response = await _service.GetExpenseAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Expense>> CreateExpenseAsync(Expense expense)
        {
            var response = await _service.CreateExpenseAsync(expense);
            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Expense>> EditExpenseAsync(Expense expense, int id)
        {
            var response = await _service.EditExpenseAsync(expense, id);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task RemoveExpense(int id)
        {
            await _service.RemoveExpense(id);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Expense>> GetExpenseDetailsAsync(int id)
        {
            var response = await _service.GetExpenseDetailsAsync(id);
            return Ok(response);
        }
    }
}