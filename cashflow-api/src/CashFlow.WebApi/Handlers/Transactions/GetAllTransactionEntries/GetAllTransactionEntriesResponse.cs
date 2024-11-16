using CashFlow.Domain.Entities.Transactions;
using CashFlow.WebApi.ViewModel.Transactions;

namespace CashFlow.WebApi.Handlers.Transactions.GetAllTransactionEntries
{
    public class GetAllTransactionEntriesResponse : List<TransactionEntryViewModel>
    {
        public GetAllTransactionEntriesResponse(List<TransactionEntry> list)
            : base(list.Select(s => new TransactionEntryViewModel(s)
            ))
        {
        }
    }
}
