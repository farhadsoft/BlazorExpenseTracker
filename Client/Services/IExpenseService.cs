using BlazorExpenseTracker.Shared.Models;

namespace BlazorExpenseTracker.Client.Services
{
    public interface IExpenseService
    {
        List<Expense> Expenses { get; set; }
        decimal TotalExpenses { get; set; }

        Task<List<Expense>> GetExpensesAsync();
        Task<Expense> CreateExpenseAsync(Expense expense);
        Task<Expense> EditExpenseAsync(Expense expense, int id);
        Task RemoveExpense(int id);
        Task<Expense> GetExpenseDetailsAsync(int id);
    }
}
