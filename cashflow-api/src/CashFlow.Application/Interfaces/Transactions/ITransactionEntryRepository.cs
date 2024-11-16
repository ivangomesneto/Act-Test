using CashFlow.Domain.Entities.Transactions;

namespace CashFlow.Application.Interfaces.Transactions
{
    public interface ITransactionEntryRepository : IGetRepository<TransactionEntry, Guid>, ISetRepository<TransactionEntry, Guid>
    {
    }
}
