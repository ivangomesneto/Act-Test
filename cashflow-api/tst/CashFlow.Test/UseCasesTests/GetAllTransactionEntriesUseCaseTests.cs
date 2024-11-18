using CashFlow.Application.Interfaces.Transactions;
using CashFlow.Application.UseCases.Transactions.GetAllTransactionEntries;
using CashFlow.Domain.Entities.Transactions;
using Moq;
using System.Linq.Expressions;

namespace CashFlow.Test.UseCasesTests
{
    public class GetAllTransactionEntriesUseCaseTests
    {
        private readonly Mock<ITransactionEntryRepository> _transactionEntryRepositoryMock;
        private readonly GetAllTransactionEntriesUseCase _useCase;

        public GetAllTransactionEntriesUseCaseTests()
        {
            _transactionEntryRepositoryMock = new Mock<ITransactionEntryRepository>();
            _useCase = new GetAllTransactionEntriesUseCase(_transactionEntryRepositoryMock.Object);
        }

        [Fact]
        public async Task Execute_ShouldReturnAllTransactions_WhenNoFiltersAreProvided()
        {
            // Arrange
            var mockTransactionEntries = new List<TransactionEntry>
            {
                new TransactionEntry(Guid.NewGuid(), DateTime.Now, "credit", "Compra", 100, null),
                new TransactionEntry(Guid.NewGuid(), DateTime.Now.AddDays(1), "debit", "Pagamento", 50, null)
            };

            _transactionEntryRepositoryMock
                .Setup(repo => repo.GetAll(It.Is<Expression<Func<TransactionEntry, bool>>>(expr => expr != null)))
                .ReturnsAsync((Expression<Func<TransactionEntry, bool>> predicate) =>
                {
                    var query = mockTransactionEntries.AsQueryable().Where(predicate);
                    return query;
                });

            // Act
            var result = await _useCase.Execute();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(mockTransactionEntries[0].Description, result.First().Description);
        }

        [Fact]
        public async Task Execute_ShouldReturnFilteredTransactions_WhenTransactionDateIsProvided()
        {
            // Arrange
            var transactionDate = DateTime.UtcNow.Date;  // Filter for today
            var mockTransactionEntries = new List<TransactionEntry>
            {
                new TransactionEntry(Guid.NewGuid(), DateTime.UtcNow, "credit", "Compra", 100, null),
                new TransactionEntry(Guid.NewGuid(), DateTime.UtcNow.AddDays(1), "debit", "Pagamento", 50, null)
            };

            _transactionEntryRepositoryMock
                .Setup(repo => repo.GetAll(It.Is<Expression<Func<TransactionEntry, bool>>>(expr => expr != null)))
                .ReturnsAsync((Expression<Func<TransactionEntry, bool>> predicate) =>
                {
                    var query = mockTransactionEntries.AsQueryable().Where(predicate);
                    return query;
                });

            // Act
            var result = await _useCase.Execute(transactionDate);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result); // Only one transaction for the given date
            Assert.Equal("Compra", result.First().Description);
        }

        [Fact]
        public async Task Execute_ShouldReturnFilteredTransactions_WhenTransactionTypeIdIsProvided()
        {
            // Arrange
            var transactionTypeId = "credit"; // Filter for "credit" transactions
            var mockTransactionEntries = new List<TransactionEntry>
            {
                new TransactionEntry(Guid.NewGuid(), DateTime.Now, "credit", "Compra", 100, null),
                new TransactionEntry(Guid.NewGuid(), DateTime.Now, "debit", "Pagamento", 50, null)
            };
            _transactionEntryRepositoryMock
                .Setup(repo => repo.GetAll(It.Is<Expression<Func<TransactionEntry, bool>>>(expr => expr != null)))
                .ReturnsAsync((Expression<Func<TransactionEntry, bool>> predicate) =>
                {
                    var query = mockTransactionEntries.AsQueryable().Where(predicate);
                    return query;
                });

            // Act
            var result = await _useCase.Execute(null, transactionTypeId);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result); // Only one "credit" transaction should be returned
            Assert.Equal("Compra", result.First().Description);
        }

        [Fact]
        public async Task Execute_ShouldReturnFilteredTransactions_WhenTransactionDateAndTransactionTypeIdAreProvided()
        {
            // Arrange
            var transactionDate = DateTime.Now.Date;
            var transactionTypeId = "credit"; // Filter for "credit" transactions on today
            var mockTransactionEntries = new List<TransactionEntry>
            {
                new TransactionEntry(Guid.NewGuid(), DateTime.Now, "credit", "Compra", 100, null),
                new TransactionEntry(Guid.NewGuid(), DateTime.Now.AddDays(1), "debit", "Pagamento", 50, null),
                new TransactionEntry(Guid.NewGuid(), DateTime.Now, "debit", "Pagamento", 50, null)
            };

            _transactionEntryRepositoryMock
                .Setup(repo => repo.GetAll(It.Is<Expression<Func<TransactionEntry, bool>>>(expr => expr != null)))
                .ReturnsAsync((Expression<Func<TransactionEntry, bool>> predicate) =>
                {
                    var query = mockTransactionEntries.AsQueryable().Where(predicate);
                    return query;
                });

            // Act
            var result = await _useCase.Execute(transactionDate, transactionTypeId);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Compra", result.First().Description);
        }

    }
}
