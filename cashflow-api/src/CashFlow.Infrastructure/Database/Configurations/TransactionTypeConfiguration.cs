using CashFlow.Domain.Entities.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashFlow.Infrastructure.Database.Configurations
{
    public class TransactionTypeConfiguration : IEntityTypeConfiguration<TransactionType>
    {
        public void Configure(EntityTypeBuilder<TransactionType> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).IsRequired().HasMaxLength(20);
            builder.Property(t => t.Name).IsRequired().HasMaxLength(30);
        }
    }
}
