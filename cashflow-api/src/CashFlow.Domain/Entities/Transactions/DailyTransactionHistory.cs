namespace CashFlow.Domain.Entities.Transactions
{
    public class DailyTransactionHistory
    {
        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public double InitialAmount { get; set; }
        public double TotalCreditAmount { get; set; }
        public double TotalDebitAmount { get; set; }
        public double FinalBalanceAmount { get; set; }
    }
}
