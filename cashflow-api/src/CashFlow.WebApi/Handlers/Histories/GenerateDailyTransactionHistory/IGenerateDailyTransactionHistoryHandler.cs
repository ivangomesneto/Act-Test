namespace CashFlow.WebApi.Handlers.Histories.GenerateDailyTransactionHistory
{
    public interface IGenerateDailyTransactionHistoryHandler
    {
        Task<GenerateDailyTransactionHistoryResponse> GenerateDailyTransactionHistory(GenerateDailyTransactionHistoryRequest request);
    }
}
