using CashFlow.Domain.Entities.Transactions;
using CashFlow.Domain.Entities.Types;
using CashFlow.Domain.Exceptions;

namespace CashFlow.Test.UnitTests
{
    public class TransactionEntryTests
    {
        [Fact]
        public void Should_Create_TransactionEntry_With_Valid_Data()
        {
            // Arrange
            var id = Guid.NewGuid();
            var transactionDate = DateTime.UtcNow;
            var transactionTypeId = "credit";
            var description = "Payment received";
            var amount = 100.0;

            // Act
            var transactionEntry = new TransactionEntry(id, transactionDate, transactionTypeId, description, amount);

            // Assert
            Assert.NotNull(transactionEntry);
            Assert.Equal(id, transactionEntry.Id);
            Assert.Equal(transactionDate, transactionEntry.TransactionDate);
            Assert.Equal(transactionTypeId, transactionEntry.TransactionTypeId);
            Assert.Equal(description, transactionEntry.Description);
            Assert.Equal(amount, transactionEntry.Amount);
        }

        [Fact]
        public void Should_Throw_Exception_When_Description_Is_Null_Or_Empty()
        {
            // Arrange
            var id = Guid.NewGuid();
            var transactionDate = DateTime.UtcNow;
            var transactionTypeId = "credit";
            string description = string.Empty;
            var amount = 100.0;

            // Act
            var exception = Assert.Throws<BusinessException>(() =>
                new TransactionEntry(id, transactionDate, transactionTypeId, description, amount));

            // Assert
            Assert.Equal("Descrição inválida", exception.Message);
        }

        [Theory]
        [InlineData("credit", -50.0)]
        [InlineData("debit", 0.0)]
        public void Should_Throw_Exception_When_Amount_Is_Invalid(string transactionTypeId, double amount)
        {
            // Arrange
            var id = Guid.NewGuid();
            var transactionDate = DateTime.UtcNow;
            var description = "Invalid amount";

            // Act
            var exception = Assert.Throws<BusinessException>(() =>
                new TransactionEntry(id, transactionDate, transactionTypeId, description, amount));

            // Assert
            Assert.Equal("Valor inválido", exception.Message);
        }

        [Fact]
        public void Should_Create_TransactionEntry_With_TransactionType()
        {
            // Arrange
            var id = Guid.NewGuid();
            var transactionDate = DateTime.UtcNow;
            var transactionTypeId = "credit";
            var description = "Payment received";
            var amount = 200.0;
            var transactionType = new TransactionType("credit", "Credit Transaction");

            // Act
            var transactionEntry = new TransactionEntry(id, transactionDate, transactionTypeId, description, amount, transactionType);

            // Assert
            Assert.NotNull(transactionEntry);
            Assert.Equal(transactionType, transactionEntry.TransactionType);
        }
    }
}
