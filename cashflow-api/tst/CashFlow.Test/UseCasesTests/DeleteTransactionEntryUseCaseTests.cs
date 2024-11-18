using CashFlow.Application.Interfaces.Transactions;
using CashFlow.Application.UseCases.Transactions.DeleteTransactionEntry;
using CashFlow.Domain.Entities.Transactions;
using CashFlow.Domain.Exceptions;
using Moq;
using System.Linq.Expressions;

namespace CashFlow.Test.UseCasesTests
{
    public class DeleteTransactionEntryUseCaseTests
    {
        private readonly Mock<ITransactionEntryRepository> _transactionEntryRepositoryMock;
        private readonly DeleteTransactionEntryUseCase _useCase;

        public DeleteTransactionEntryUseCaseTests()
        {
            _transactionEntryRepositoryMock = new Mock<ITransactionEntryRepository>();
            _useCase = new DeleteTransactionEntryUseCase(_transactionEntryRepositoryMock.Object);
        }

        [Fact]
        public async Task Execute_ShouldThrowBusinessException_WhenTransactionDoesNotExist()
        {
            // Arrange
            var transactionEntryId = Guid.NewGuid();

            // Mock do repositório para retornar uma lista vazia (sem transações)
            _transactionEntryRepositoryMock
                .Setup(repo => repo.GetAll(It.IsAny<Expression<Func<TransactionEntry, bool>>>()))
                .ReturnsAsync(Enumerable.Empty<TransactionEntry>().AsQueryable());

            // Act & Assert
            var exception = await Assert.ThrowsAsync<BusinessException>(() =>
                _useCase.Execute(transactionEntryId));

            Assert.Equal("Transação não encontrada", exception.Message);
        }

        [Fact]
        public async Task Execute_ShouldCallDelete_WhenTransactionExists()
        {
            // Arrange
            var transactionEntryId = Guid.NewGuid();
            var mockTransactionEntry = new TransactionEntry(transactionEntryId, DateTime.Now, "credit", "Compra", 100, null);

            // Mock do repositório para retornar a transação
            _transactionEntryRepositoryMock
                .Setup(repo => repo.GetAll(It.IsAny<Expression<Func<TransactionEntry, bool>>>()))
                .ReturnsAsync(new[] { mockTransactionEntry }.AsQueryable());

            // Act
            await _useCase.Execute(transactionEntryId);

            // Assert
            _transactionEntryRepositoryMock.Verify(repo => repo.Delete(transactionEntryId), Times.Once);
        }
    }
}
