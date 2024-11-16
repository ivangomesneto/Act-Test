namespace CashFlow.WebApi.Handlers.Transactions.AddTransactionEntry
{
    public interface IAddTransactionEntryHandler
    {
        Task<AddTransactionEntryResponse> AddTransactionEntry(AddTransactionEntryRequest request);
    }
}
