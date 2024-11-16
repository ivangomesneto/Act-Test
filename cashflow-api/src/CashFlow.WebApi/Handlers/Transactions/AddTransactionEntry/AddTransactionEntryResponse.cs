using CashFlow.Domain.Entities.Transactions;
using CashFlow.WebApi.ViewModel.Transactions;

namespace CashFlow.WebApi.Handlers.Transactions.AddTransactionEntry
{
    public class AddTransactionEntryResponse : TransactionEntryViewModel
    {
        public AddTransactionEntryResponse(TransactionEntry transactionEntry) : base(transactionEntry)
        {
        }
    }
}
