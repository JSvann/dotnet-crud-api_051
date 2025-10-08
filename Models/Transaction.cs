namespace dotnet_crud_api.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int BudgetId { get; set; } // Ini menghubungkan transaksi ke sebuah budget
    }
}