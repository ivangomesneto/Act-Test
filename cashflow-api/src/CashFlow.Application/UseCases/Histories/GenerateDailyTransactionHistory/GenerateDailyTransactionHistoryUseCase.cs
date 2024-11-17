using CashFlow.Application.Interfaces.Histories;
using CashFlow.Application.Interfaces.Transactions;
using CashFlow.Domain.Entities.Histories;
using CashFlow.Domain.Exceptions;

namespace CashFlow.Application.UseCases.Histories.GenerateDailyTransactionHistory
{
    public class GenerateDailyTransactionHistoryUseCase : IGenerateDailyTransactionHistoryUseCase
    {
        private readonly ITransactionEntryRepository _transactionEntryRepository;
        private readonly IDailyTransactionHistoryRepository _dailyTransactionHistoryRepository;

        public GenerateDailyTransactionHistoryUseCase(ITransactionEntryRepository transactionEntryRepository,
            IDailyTransactionHistoryRepository dailyTransactionHistoryRepository)
        {
            _transactionEntryRepository = transactionEntryRepository;
            _dailyTransactionHistoryRepository = dailyTransactionHistoryRepository;
        }

        public async Task<DailyTransactionHistory> Execute(DateTime date)
        {
            var dailyTransactionHistory = (await _dailyTransactionHistoryRepository.GetAll(g => g.Date == date.Date)).FirstOrDefault();

            if (dailyTransactionHistory != null)
                throw new BusinessException($"Já existe uma consolidação para o dia {date:dd/MM/yyyy}");

            var transactions = await _transactionEntryRepository.GetAll(g => g.TransactionDate >= date.Date && g.TransactionDate <= date.Date.AddDays(1).AddSeconds(-1));

            if (!transactions.Any())
                throw new BusinessException($"Nenhum lançamento efetuado para o dia {date:dd/MM/yyyy}");

            var summary = new
            {
                InitialAmount = transactions.Where(s => s.TransactionTypeId == "initialbalance").Sum(s => s.Amount),
                TotalCreditAmount = transactions.Where(s => s.TransactionTypeId == "credit").Sum(s => s.Amount),
                TotalDebitAmount = transactions.Where(s => s.TransactionTypeId == "debit").Sum(s => s.Amount),
            };

            dailyTransactionHistory = new DailyTransactionHistory(Guid.NewGuid(), date.Date, summary.InitialAmount, summary.TotalCreditAmount, summary.TotalDebitAmount, summary.InitialAmount + summary.TotalCreditAmount - summary.TotalDebitAmount);

            return await _dailyTransactionHistoryRepository.Insert(dailyTransactionHistory);
        }
    }
}
