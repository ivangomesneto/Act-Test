namespace CashFlow.WebApi.Handlers.Transactions.AddTransactionEntry
{
    public class AddTransactionEntryRequest
    {
        public DateTime TransactionDate { get; set; }
        public string TransactionTypeId { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
    }
}
