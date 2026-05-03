namespace sulek_zadanie_3.Models
{
    public class Transaction
    {
        public decimal Amount { get; set; }
        public string Category { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; }
        public string? Note { get; set; }
    }
}
