using CashFlow.Domain.Entities.Transactions;

namespace CashFlow.Application.UseCases.AddTransactionEntry
{
    public interface IAddTransactionEntryUseCase
    {
        Task<TransactionEntry> Execute(DateTime transactionDate, string transactionTypeId, string description, double amount);
    }
}
