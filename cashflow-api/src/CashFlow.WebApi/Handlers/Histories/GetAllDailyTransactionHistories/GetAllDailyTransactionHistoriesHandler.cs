using CashFlow.Application.UseCases.Histories.GetAllDailyTransactionHistories;

namespace CashFlow.WebApi.Handlers.Histories.GetAllDailyTransactionHistories
{
    public class GetAllDailyTransactionHistoriesHandler : IGetAllDailyTransactionHistoriesHandler
    {
        private readonly IGetAllDailyTransactionHistoriesUseCase _useCase;

        public GetAllDailyTransactionHistoriesHandler(IGetAllDailyTransactionHistoriesUseCase useCase)
        {
            _useCase = useCase;
        }

        public async Task<GetAllDailyTransactionHistoriesResponse> GetAllDailyTransactionHistories(DateTime? date = null)
        {
            var list = await _useCase.Execute(date);

            return new GetAllDailyTransactionHistoriesResponse(list.ToList());
        }
    }
}
