using CashFlow.Domain.Entities.Types;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.Database.DataAccess
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<TransactionType>().HasData(
                new { Id = "initialbalance", Name = "Saldo Inicial" },
                new { Id = "credit", Name = "Crédito" },
                new { Id = "debit", Name = "Débito" }
            );
        }
    }
}
