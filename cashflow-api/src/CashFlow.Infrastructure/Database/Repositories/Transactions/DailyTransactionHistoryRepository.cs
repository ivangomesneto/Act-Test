using CashFlow.Application.Interfaces.Transactions;
using CashFlow.Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.Database.Repositories.Transactions
{
    public class DailyTransactionHistoryRepository(DbContext context) : BaseRepository<DailyTransactionHistory, Guid>(context), IDailyTransactionHistoryRepository
    {
    }
}
