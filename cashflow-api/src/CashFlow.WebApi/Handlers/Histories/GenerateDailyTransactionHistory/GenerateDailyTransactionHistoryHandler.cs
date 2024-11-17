using CashFlow.Application.UseCases.Histories.GenerateDailyTransactionHistory;

namespace CashFlow.WebApi.Handlers.Histories.GenerateDailyTransactionHistory
{
    public class GenerateDailyTransactionHistoryHandler : IGenerateDailyTransactionHistoryHandler
    {
        private readonly IGenerateDailyTransactionHistoryUseCase _useCase;

        public GenerateDailyTransactionHistoryHandler(IGenerateDailyTransactionHistoryUseCase useCase)
        {
            _useCase = useCase;
        }

        public async Task<GenerateDailyTransactionHistoryResponse> GenerateDailyTransactionHistory(GenerateDailyTransactionHistoryRequest request)
        {
            return new GenerateDailyTransactionHistoryResponse((await _useCase.Execute(request.Date)));
        }
    }
}
