using CashFlow.Application.Interfaces.Histories;
using CashFlow.Domain.Entities.Histories;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.Database.Repositories.Histories
{
    public class DailyTransactionHistoryRepository(DbContext context) : BaseRepository<DailyTransactionHistory, Guid>(context), IDailyTransactionHistoryRepository
    {
    }
}
