using CashFlow.Application.Interfaces.Histories;
using CashFlow.Domain.Entities.Histories;

namespace CashFlow.Application.UseCases.Histories.GetAllDailyTransactionHistories
{
    public class GetAllDailyTransactionHistoriesUseCase : IGetAllDailyTransactionHistoriesUseCase
    {
        private readonly IDailyTransactionHistoryRepository _dailyTransactionHistoryRepository;

        public GetAllDailyTransactionHistoriesUseCase(IDailyTransactionHistoryRepository dailyTransactionHistoryRepository)
        {
            _dailyTransactionHistoryRepository = dailyTransactionHistoryRepository;
        }

        public async Task<IEnumerable<DailyTransactionHistory>> Execute(DateTime? date = null)
        {
            var query = await _dailyTransactionHistoryRepository.GetAll(g => !date.HasValue || g.Date == date.Value.Date);

            return query.OrderBy(o => o.Date).Select(s => new DailyTransactionHistory(s.Id, s.Date, s.InitialAmount, s.TotalCreditAmount, s.TotalDebitAmount, s.FinalBalanceAmount)).ToList();
        }
    }
}
