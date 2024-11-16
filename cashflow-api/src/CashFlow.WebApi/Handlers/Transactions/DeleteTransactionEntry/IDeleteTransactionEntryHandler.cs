namespace CashFlow.WebApi.Handlers.Transactions.DeleteTransactionEntry
{
    public interface IDeleteTransactionEntryHandler
    {
        Task DeleteTransactionEntry(Guid transactionEntryId);
    }
}
