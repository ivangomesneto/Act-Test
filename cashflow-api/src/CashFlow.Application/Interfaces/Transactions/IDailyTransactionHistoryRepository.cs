using CashFlow.Domain.Entities.Transactions;

namespace CashFlow.Application.Interfaces.Transactions
{
    public interface IDailyTransactionHistoryRepository : IGetRepository<DailyTransactionHistory, Guid>, ISetRepository<DailyTransactionHistory, Guid>
    {
    }
}
