using CashFlow.Application.Interfaces.Transactions;
using CashFlow.Domain.Entities.Transactions;
using CashFlow.Domain.Exceptions;

namespace CashFlow.Application.UseCases.Transactions.AddTransactionEntry
{
    public class AddTransactionEntryUseCase : IAddTransactionEntryUseCase
    {
        private readonly ITransactionEntryRepository _transactionEntryRepository;

        public AddTransactionEntryUseCase(ITransactionEntryRepository transactionEntryRepository)
        {
            _transactionEntryRepository = transactionEntryRepository;
        }

        public async Task<TransactionEntry> Execute(DateTime transactionDate, string transactionTypeId, string description, double amount)
        {
            if ((await _transactionEntryRepository.GetAll(g => g.TransactionDate >= transactionDate.Date && g.TransactionDate <= transactionDate.Date.AddDays(1).AddSeconds(-1) &&
                g.Description == description &&
                g.TransactionTypeId == transactionTypeId &&
                g.Amount == amount)).Any())
            {
                throw new BusinessException("Lançamento já realizado");
            }

            if (transactionTypeId != "initialbalance" && !(await _transactionEntryRepository.GetAll(g => g.TransactionDate == transactionDate.Date &&
                g.TransactionTypeId == "initialbalance")).Any())
            {
                throw new BusinessException("É necessário lançar o saldo inicial do dia antes de lançar os movimentos");
            }

            //See for o balanço inicial do dia, considera apenas a data com 00:00
            if (transactionTypeId == "initialbalance")
            {
                transactionDate = transactionDate.Date;
            }

            var transactionEntry = new TransactionEntry(Guid.NewGuid(), transactionDate, transactionTypeId, description, amount);

            return await _transactionEntryRepository.Insert(transactionEntry);
        }
    }
}
