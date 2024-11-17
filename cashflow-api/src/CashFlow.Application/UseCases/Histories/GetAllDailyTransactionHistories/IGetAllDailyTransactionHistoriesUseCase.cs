using CashFlow.Domain.Entities.Histories;

namespace CashFlow.Application.UseCases.Histories.GetAllDailyTransactionHistories
{
    public interface IGetAllDailyTransactionHistoriesUseCase
    {
        Task<IEnumerable<DailyTransactionHistory>> Execute(DateTime? date = null);
    }
}
