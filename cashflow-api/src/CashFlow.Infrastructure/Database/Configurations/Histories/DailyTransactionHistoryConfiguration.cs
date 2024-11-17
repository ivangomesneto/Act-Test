using CashFlow.Domain.Entities.Histories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashFlow.Infrastructure.Database.Configurations.Histories
{
    public class DailyTransactionHistoryConfiguration : IEntityTypeConfiguration<DailyTransactionHistory>
    {
        public void Configure(EntityTypeBuilder<DailyTransactionHistory> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id).ValueGeneratedNever();
            builder.Property(d => d.Date).IsRequired();
            builder.Property(d => d.InitialAmount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(d => d.TotalCreditAmount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(d => d.TotalDebitAmount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(d => d.FinalBalanceAmount).IsRequired().HasColumnType("decimal(18,2)");
        }
    }
}
