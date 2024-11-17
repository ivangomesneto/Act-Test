using CashFlow.Domain.Entities.Histories;
using CashFlow.WebApi.ViewModel.Histories;

namespace CashFlow.WebApi.Handlers.Histories.GenerateDailyTransactionHistory
{
    public class GenerateDailyTransactionHistoryResponse : DailyTransactionHistoryViewModel
    {
        public GenerateDailyTransactionHistoryResponse(DailyTransactionHistory dailyTransactionHistory) : base(dailyTransactionHistory)
        {
        }
    }
}
