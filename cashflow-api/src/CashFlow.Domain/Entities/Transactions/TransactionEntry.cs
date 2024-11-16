using CashFlow.Domain.Entities.Types;

namespace CashFlow.Domain.Entities.Transactions
{
    public class TransactionEntry(Guid id, DateTime transactionDate, string transactionTypeId, string description, double amount)
    {
        public TransactionEntry(Guid id, DateTime transactionDate, string transactionTypeId, string description, double amount, TransactionType transactionType) : this(id, transactionDate, transactionTypeId, description, amount)
        {
            TransactionType = transactionType;
        }

        public Guid Id { get; private set; } = id;
        public DateTime TransactionDate { get; private set; } = transactionDate;
        public string TransactionTypeId { get; private set; } = transactionTypeId;
        public string Description { get; private set; } = description;
        public double Amount { get; private set; } = amount;

        public TransactionType? TransactionType { get; private set; }
    }
}
