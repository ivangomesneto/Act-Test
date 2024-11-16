using CashFlow.Application.Interfaces.Transactions;
using CashFlow.Domain.Entities.Transactions;

namespace CashFlow.Application.UseCases.GetAllTransactionEntries
{
    public class GetAllTransactionEntriesUseCase : IGetAllTransactionEntriesUseCase
    {
        private readonly ITransactionEntryRepository _transactionEntryRepository;

        public GetAllTransactionEntriesUseCase(ITransactionEntryRepository transactionEntryRepository)
        {
            _transactionEntryRepository = transactionEntryRepository;
        }

        public async Task<IEnumerable<TransactionEntry>> Execute(DateTime? transactionDate = null, string? transactionTypeId = null)
        {
            var query = await _transactionEntryRepository.GetAll(g =>
                (!transactionDate.HasValue || (g.TransactionDate >= transactionDate.Value.Date && g.TransactionDate <= transactionDate.Value.Date.AddDays(1).AddSeconds(-1))) &&
                (string.IsNullOrEmpty(transactionTypeId) || g.TransactionTypeId == transactionTypeId));

            return query.OrderBy(o => o.TransactionDate).Select(s => new TransactionEntry(s.Id, s.TransactionDate, s.TransactionTypeId, s.Description, s.Amount, s.TransactionType!)).ToList();
        }
    }
}
