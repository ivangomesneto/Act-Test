using CashFlow.Domain.Entities.Transactions;

namespace CashFlow.Application.UseCases.GetAllTransactionEntries
{
    public interface IGetAllTransactionEntriesUseCase
    {
        Task<IEnumerable<TransactionEntry>> Execute(DateTime? transactionDate = null, string? transactionTypeId = null);
    }
}
