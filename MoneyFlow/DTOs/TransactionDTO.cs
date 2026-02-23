using MoneyFlow.Entities;

namespace MoneyFlow.DTOs
{
    public class TransactionDTO
    {
        public int TransactionId { get; set; }
        public int ServiceId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public DateOnly Date { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
