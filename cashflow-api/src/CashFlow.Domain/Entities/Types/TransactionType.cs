namespace CashFlow.Domain.Entities.Types
{
    public class TransactionType(string id, string name)
    {
        public string Id { get; set; } = id;
        public string Name { get; set; } = name;
    }
}
