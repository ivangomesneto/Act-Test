namespace CashFlow.WebApi.Handlers.Transactions.GetAllTransactionEntries
{
    public interface IGetAllTransactionEntriesHandler
    {
        Task<GetAllTransactionEntriesResponse> GetTransactionEntries(DateTime? transactionDate = null, string? transactionTypeId = null);
    }
}
