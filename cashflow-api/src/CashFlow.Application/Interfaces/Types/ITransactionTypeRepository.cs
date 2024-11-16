using CashFlow.Domain.Entities.Types;

namespace CashFlow.Application.Interfaces.Types
{
    public interface ITransactionTypeRepository : IGetRepository<TransactionType>, ISetRepository<TransactionType>
    {
    }
}
