using CashFlow.Application.Interfaces.Transactions;
using CashFlow.Application.UseCases.Transactions.AddTransactionEntry;
using CashFlow.Domain.Entities.Transactions;
using CashFlow.Domain.Exceptions;
using Moq;
using System.Linq.Expressions;

namespace CashFlow.Test.UseCasesTests
{
    public class AddTransactionEntryUseCaseTests
    {
        private readonly Mock<ITransactionEntryRepository> _transactionEntryRepositoryMock;
        private readonly AddTransactionEntryUseCase _useCase;

        public AddTransactionEntryUseCaseTests()
        {
            _transactionEntryRepositoryMock = new Mock<ITransactionEntryRepository>();
            _useCase = new AddTransactionEntryUseCase(_transactionEntryRepositoryMock.Object);
        }

        [Fact]
        public async Task Execute_ShouldThrowException_WhenTransactionAlreadyExists()
        {
            // Arrange
            var transactionDate = DateTime.Now;
            var transactionTypeId = "credit";
            var description = "Compra";
            var amount = 100;

            var transactionEntries = new List<TransactionEntry>
            {
                new TransactionEntry(Guid.NewGuid(), transactionDate, transactionTypeId, description, amount)
            }.AsQueryable();

            _transactionEntryRepositoryMock
                .Setup(repo => repo.GetAll(It.IsAny<Expression<Func<TransactionEntry, bool>>>()))
                .ReturnsAsync(transactionEntries);

            // Act & Assert
            await Assert.ThrowsAsync<BusinessException>(() =>
                _useCase.Execute(transactionDate, transactionTypeId, description, amount));
        }

        [Fact]
        public async Task Execute_ShouldThrowException_WhenInitialBalanceNotExistsForDay()
        {
            // Arrange
            var transactionDate = DateTime.Now;
            var transactionTypeId = "credit";
            var description = "Compra";
            var amount = 100;

            _transactionEntryRepositoryMock
                .Setup(repo => repo.GetAll(It.IsAny<Expression<Func<TransactionEntry, bool>>>()))
                .ReturnsAsync(new List<TransactionEntry>().AsQueryable());

            // Act & Assert
            var exception = await Assert.ThrowsAsync<BusinessException>(() =>
                _useCase.Execute(transactionDate, transactionTypeId, description, amount));

            Assert.Equal("É necessário lançar o saldo inicial do dia antes de lançar os movimentos", exception.Message);
        }

        [Fact]
        public async Task Execute_ShouldSetTransactionDateToMidnight_ForInitialBalance()
        {
            // Arrange
            var transactionDate = DateTime.Now;
            var transactionTypeId = "initialbalance";
            var description = "Saldo inicial";
            var amount = 100;

            _transactionEntryRepositoryMock
                .Setup(repo => repo.GetAll(It.IsAny<Expression<Func<TransactionEntry, bool>>>()))
                .ReturnsAsync(new List<TransactionEntry>().AsQueryable());

            _transactionEntryRepositoryMock
                .Setup(repo => repo.Insert(It.IsAny<TransactionEntry>()))
                .ReturnsAsync((TransactionEntry entry) => entry);

            // Act
            var result = await _useCase.Execute(transactionDate, transactionTypeId, description, amount);

            // Assert
            Assert.Equal(transactionDate.Date, result.TransactionDate);
        }

        [Fact]
        public async Task Execute_ShouldInsertTransactionEntry_WhenValid()
        {
            // Arrange
            var transactionDate = DateTime.Now;
            var transactionTypeId = "credit";
            var description = "Compra";
            var amount = 100;

            _transactionEntryRepositoryMock
                .SetupSequence(repo => repo.GetAll(It.IsAny<Expression<Func<TransactionEntry, bool>>>()))
                .ReturnsAsync(new List<TransactionEntry>().AsQueryable())
                .ReturnsAsync(new List<TransactionEntry>
                {
            new TransactionEntry(Guid.NewGuid(), transactionDate.Date, "initialbalance", "Saldo inicial", 100)
                }.AsQueryable());

            _transactionEntryRepositoryMock
                .Setup(repo => repo.Insert(It.IsAny<TransactionEntry>()))
                .ReturnsAsync((TransactionEntry entry) => entry);

            // Act
            var result = await _useCase.Execute(transactionDate, transactionTypeId, description, amount);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(transactionTypeId, result.TransactionTypeId);
            Assert.Equal(description, result.Description);
            Assert.Equal(amount, result.Amount);
        }

    }
}
