using BlazorExpenseTracker.Server.Data;
using BlazorExpenseTracker.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorExpenseTracker.Server.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly DataContext _context;

        public ExpenseService(DataContext context)
        {
            _context = context;
        }

        public async Task<Expense> CreateExpenseAsync(Expense expense)
        {
            var response = await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<Expense> EditExpenseAsync(Expense expense, int id)
        {
            Expense response = default!;

            var DbExpense = await _context.Expenses.FirstOrDefaultAsync(e => e.Id == id);

            if (DbExpense != null)
            {
                DbExpense.Title = expense.Title;
                DbExpense.Description = expense.Description;
                DbExpense.Amount = expense.Amount;
                DbExpense.CreatedAt = expense.CreatedAt;


                await _context.SaveChangesAsync();

                response = DbExpense;
            }

            return response;
        }

        public async Task<List<Expense>> GetExpenseAsync()
        {
            var responce = await _context.Expenses.ToListAsync();
            return responce;
        }

        public async Task<Expense> GetExpenseDetailsAsync(int id)
        {
            var response = await _context.Expenses.FirstOrDefaultAsync(e => e.Id == id);
            return response;
        }

        public async Task RemoveExpense(int id)
        {
            var DbTransaction = await _context.Expenses.FirstOrDefaultAsync(e => e.Id == id);

            if (DbTransaction != null)
            {
                _context.Expenses.Remove(DbTransaction);
            }

            await _context.SaveChangesAsync();
        }
    }
}
