namespace CashFlow.WebApi.Handlers.Histories.GetAllDailyTransactionHistories
{
    public interface IGetAllDailyTransactionHistoriesHandler
    {
        Task<GetAllDailyTransactionHistoriesResponse> GetAllDailyTransactionHistories(DateTime? date = null);
    }
}
