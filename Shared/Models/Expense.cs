using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorExpenseTracker.Shared.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; } = 0.0M;
        public DateTime CreatedAt { get; set; }
    }
}
