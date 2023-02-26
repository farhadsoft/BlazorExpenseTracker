using BlazorExpenseTracker.Shared.Models;
using System.Net.Http.Json;

namespace BlazorExpenseTracker.Client.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly HttpClient _http;

        public ExpenseService(HttpClient http)
        {
            _http = http;
        }

        public List<Expense> Expenses { get; set; } = new List<Expense>();
        public decimal TotalExpenses { get; set; } = 0.0M;

        public async Task<Expense> CreateExpenseAsync(Expense expense)
        {
            var response = await _http.PostAsJsonAsync<Expense>("/api/Expenses", expense);
            return await response.Content.ReadFromJsonAsync<Expense>();
        }

        public async Task<Expense> EditExpenseAsync(Expense expense, int id)
        {
            var response = await _http.PutAsJsonAsync<Expense>($"/api/Expenses/{id}", expense);
            return await response.Content.ReadFromJsonAsync<Expense>();
        }

        public async Task<List<Expense>> GetExpensesAsync()
        {
            var response = await _http.GetFromJsonAsync<List<Expense>>("/api/Expenses");

            if (response != null)
            {
                Expenses = response;
                CalculateTotalExpenses();

            }

            return Expenses;

        }


        public async Task RemoveExpense(int id)
        {
            await _http.DeleteAsync($"/api/Expenses/{id}");
        }

        private void CalculateTotalExpenses()
        {
            TotalExpenses = 0;

            foreach (var expense in Expenses)
            {
                TotalExpenses += expense.Amount;
            }
        }

        public async Task<Expense> GetExpenseDetailsAsync(int id)
        {
            var response = await _http.GetFromJsonAsync<Expense>($"/api/Expenses/{id}");

            return response;

        }
    }
}
