using CashFlow.Application.Interfaces.Types;
using CashFlow.Domain.Entities.Types;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.Database.Repositories.Types
{
    internal class TransactionTypeRepository(DbContext context) : BaseRepository<TransactionType>(context), ITransactionTypeRepository
    {
    }
}
