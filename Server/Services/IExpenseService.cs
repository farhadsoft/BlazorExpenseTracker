using BlazorExpenseTracker.Shared.Models;

namespace BlazorExpenseTracker.Server.Services
{
    public interface IExpenseService
    {
        Task<List<Expense>> GetExpenseAsync();
        Task<Expense> CreateExpenseAsync(Expense expense);
        Task<Expense> EditExpenseAsync(Expense expense, int id);
        Task RemoveExpense(int id);

        Task<Expense> GetExpenseDetailsAsync(int id);
    }
}
