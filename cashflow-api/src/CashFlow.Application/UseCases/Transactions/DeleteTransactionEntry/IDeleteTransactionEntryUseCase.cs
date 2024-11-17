namespace CashFlow.Application.UseCases.Transactions.DeleteTransactionEntry
{
    public interface IDeleteTransactionEntryUseCase
    {
        Task Execute(Guid transactionEntryId);
    }
}
