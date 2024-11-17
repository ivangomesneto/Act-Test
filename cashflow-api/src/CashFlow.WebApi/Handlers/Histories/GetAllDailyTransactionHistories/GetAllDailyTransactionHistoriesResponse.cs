using CashFlow.Domain.Entities.Histories;
using CashFlow.WebApi.ViewModel.Histories;

namespace CashFlow.WebApi.Handlers.Histories.GetAllDailyTransactionHistories
{
    public class GetAllDailyTransactionHistoriesResponse : List<DailyTransactionHistoryViewModel>
    {
        public GetAllDailyTransactionHistoriesResponse(List<DailyTransactionHistory> list)
            : base(list.Select(s => new DailyTransactionHistoryViewModel(s)
            ))
        {
        }
    }
}
