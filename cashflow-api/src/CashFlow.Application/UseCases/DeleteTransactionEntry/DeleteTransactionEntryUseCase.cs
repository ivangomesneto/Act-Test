using CashFlow.Application.Interfaces.Transactions;
using CashFlow.Domain.Exceptions;

namespace CashFlow.Application.UseCases.DeleteTransactionEntry
{
    public class DeleteTransactionEntryUseCase : IDeleteTransactionEntryUseCase
    {
        private readonly ITransactionEntryRepository _transactionEntryRepository;

        public DeleteTransactionEntryUseCase(ITransactionEntryRepository transactionEntryRepository)
        {
            _transactionEntryRepository = transactionEntryRepository;
        }

        public async Task Execute(Guid transactionEntryId)
        {
            if (!(await _transactionEntryRepository.GetAll(g => g.Id == transactionEntryId)).Any())
            {
                throw new BusinessException("Transação não encontrada");
            }

            await _transactionEntryRepository.Delete(transactionEntryId);
        }
    }
}
