using CashFlow.Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashFlow.Infrastructure.Database.Configurations.Transactions
{
    public class TransactionEntryConfiguration : IEntityTypeConfiguration<TransactionEntry>
    {
        public void Configure(EntityTypeBuilder<TransactionEntry> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).ValueGeneratedNever();
            builder.Property(t => t.TransactionDate).IsRequired();
            builder.Property(t => t.TransactionTypeId).IsRequired().HasMaxLength(20);
            builder.Property(t => t.Description).IsRequired().HasMaxLength(200);
            builder.Property(t => t.Amount).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasOne(t => t.TransactionType).WithMany().HasForeignKey(t => t.TransactionTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
