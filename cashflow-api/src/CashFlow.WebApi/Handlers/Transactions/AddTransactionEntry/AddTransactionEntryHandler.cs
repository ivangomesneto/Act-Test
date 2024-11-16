using CashFlow.Application.UseCases.AddTransactionEntry;

namespace CashFlow.WebApi.Handlers.Transactions.AddTransactionEntry
{
    public class AddTransactionEntryHandler : IAddTransactionEntryHandler
    {
        private readonly IAddTransactionEntryUseCase _useCase;

        public AddTransactionEntryHandler(IAddTransactionEntryUseCase useCase)
        {
            _useCase = useCase;
        }

        public async Task<AddTransactionEntryResponse> AddTransactionEntry(AddTransactionEntryRequest request)
        {
            return new AddTransactionEntryResponse((await _useCase.Execute(request.TransactionDate, request.TransactionTypeId, request.Description, request.Amount)));
        }
    }
}
