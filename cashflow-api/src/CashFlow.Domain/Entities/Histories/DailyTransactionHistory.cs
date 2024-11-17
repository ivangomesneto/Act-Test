namespace CashFlow.Domain.Entities.Histories
{
    public class DailyTransactionHistory(Guid id, DateTime date, double initialAmount, double totalCreditAmount, double totalDebitAmount, double finalBalanceAmount)
    {
        public Guid Id { get; private set; } = id;
        public DateTime Date { get; private set; } = date;
        public double InitialAmount { get; private set; } = initialAmount;
        public double TotalCreditAmount { get; private set; } = totalCreditAmount;
        public double TotalDebitAmount { get; private set; } = totalDebitAmount;
        public double FinalBalanceAmount { get; private set; } = finalBalanceAmount;
    }
}
