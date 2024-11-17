using CashFlow.Application.UseCases.Transactions.DeleteTransactionEntry;

namespace CashFlow.WebApi.Handlers.Transactions.DeleteTransactionEntry
{
    public class DeleteTransactionEntryHandler : IDeleteTransactionEntryHandler
    {
        private readonly IDeleteTransactionEntryUseCase _useCase;

        public DeleteTransactionEntryHandler(IDeleteTransactionEntryUseCase useCase)
        {
            _useCase = useCase;
        }

        public async Task DeleteTransactionEntry(Guid transactionEntryId)
        {
            await _useCase.Execute(transactionEntryId);
        }
    }
}
