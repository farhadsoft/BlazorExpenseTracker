using BlazorExpenseTracker.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorExpenseTracker.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Expense> Expenses { get; set; }
    }
}
