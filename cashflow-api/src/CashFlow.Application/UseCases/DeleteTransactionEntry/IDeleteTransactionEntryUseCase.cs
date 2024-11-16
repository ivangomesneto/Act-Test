namespace CashFlow.Application.UseCases.DeleteTransactionEntry
{
    public interface IDeleteTransactionEntryUseCase
    {
        Task Execute(Guid transactionEntryId);
    }
}
