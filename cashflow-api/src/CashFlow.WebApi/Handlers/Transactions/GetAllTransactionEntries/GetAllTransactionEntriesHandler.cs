using CashFlow.Application.UseCases.Transactions.GetAllTransactionEntries;

namespace CashFlow.WebApi.Handlers.Transactions.GetAllTransactionEntries
{
    public class GetAllTransactionEntriesHandler : IGetAllTransactionEntriesHandler
    {
        private readonly IGetAllTransactionEntriesUseCase _useCase;

        public GetAllTransactionEntriesHandler(IGetAllTransactionEntriesUseCase useCase)
        {
            _useCase = useCase;
        }

        public async Task<GetAllTransactionEntriesResponse> GetTransactionEntries(DateTime? transactionDate = null, string? transactionTypeId = null)
        {
            var list = await _useCase.Execute(transactionDate, transactionTypeId);

            return new GetAllTransactionEntriesResponse(list.ToList());
        }
    }
}
