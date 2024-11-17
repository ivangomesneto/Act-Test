using CashFlow.Domain.Entities.Transactions;

namespace CashFlow.WebApi.ViewModel.Transactions
{
    public class TransactionEntryViewModel(TransactionEntry transactionEntry)
    {
        public Guid Id { get; set; } = transactionEntry.Id;
        public string TransactionDate { get; set; } = transactionEntry.TransactionDate.ToString("dd/MM/yyyy HH:mm");
        public string TransactionTypeId { get; set; } = transactionEntry.TransactionTypeId;
        public string? TransactionType { get; set; } = transactionEntry.TransactionType?.Name;
        public string Description { get; set; } = transactionEntry.Description;
        public string Amount { get; set; } = $"R$ {transactionEntry.Amount:0.00}";
    }
}
