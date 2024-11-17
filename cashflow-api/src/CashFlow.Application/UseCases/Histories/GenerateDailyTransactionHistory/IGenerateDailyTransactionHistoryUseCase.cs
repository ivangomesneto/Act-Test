using CashFlow.Domain.Entities.Histories;

namespace CashFlow.Application.UseCases.Histories.GenerateDailyTransactionHistory
{
    public interface IGenerateDailyTransactionHistoryUseCase
    {
        Task<DailyTransactionHistory> Execute(DateTime date);
    }
}
