using CashFlow.Domain.Entities.Histories;

namespace CashFlow.WebApi.ViewModel.Histories
{
    public class DailyTransactionHistoryViewModel(DailyTransactionHistory dailyTransactionHistory)
    {
        public Guid Id { get; private set; } = dailyTransactionHistory.Id;
        public string Date { get; private set; } = dailyTransactionHistory.Date.ToString("dd/MM/yyyy");
        public string InitialAmount { get; set; } = $"R$ {dailyTransactionHistory.InitialAmount:0.00}";
        public string TotalCreditAmount { get; set; } = $"R$ {dailyTransactionHistory.TotalCreditAmount:0.00}"; 
        public string TotalDebitAmount { get; set; } = $"R$ {dailyTransactionHistory.TotalDebitAmount:0.00}"; 
        public string FinalBalanceAmount { get; set; } = $"R$ {dailyTransactionHistory.FinalBalanceAmount:0.00}"; 
    }
}
