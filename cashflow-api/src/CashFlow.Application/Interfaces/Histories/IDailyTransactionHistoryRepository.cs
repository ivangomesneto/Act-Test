using CashFlow.Domain.Entities.Histories;

namespace CashFlow.Application.Interfaces.Histories
{
    public interface IDailyTransactionHistoryRepository : IGetRepository<DailyTransactionHistory, Guid>, ISetRepository<DailyTransactionHistory, Guid>
    {
    }
}
