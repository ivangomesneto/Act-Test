using CashFlow.Application.Interfaces.Transactions;
using CashFlow.Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.Database.Repositories.Transactions
{
    public class TransactionEntryRepository(DbContext context) : BaseRepository<TransactionEntry, Guid>(context), ITransactionEntryRepository
    {
    }
}
