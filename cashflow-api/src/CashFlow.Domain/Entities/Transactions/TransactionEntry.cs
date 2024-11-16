using CashFlow.Domain.Entities.Types;
using CashFlow.Domain.Exceptions;

namespace CashFlow.Domain.Entities.Transactions
{
    public class TransactionEntry
    {
        public TransactionEntry(Guid id, DateTime transactionDate, string transactionTypeId, string description, double amount)
        {
            Id = id;
            TransactionDate = transactionDate;
            TransactionTypeId = transactionTypeId;
            Description = description;
            Amount = amount;

            Validate();
        }

        public TransactionEntry(Guid id, DateTime transactionDate, string transactionTypeId, string description, double amount, TransactionType transactionType) : this(id, transactionDate, transactionTypeId, description, amount)
        {
            TransactionType = transactionType;
        }

        public Guid Id { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public string TransactionTypeId { get; private set; }
        public string Description { get; private set; }
        public double Amount { get; private set; }

        public TransactionType? TransactionType { get; private set; }

        private void Validate()
        {
            if (string.IsNullOrEmpty(Description))
            {
                throw new BusinessException("Descrição inválida");
            }

            if (TransactionTypeId != "initialbalance" && Amount <= 0)
            {
                throw new BusinessException("Valor inválido");
            }
        }
    }
}
