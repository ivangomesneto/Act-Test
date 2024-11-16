using CashFlow.Infrastructure.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.Database.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        //Aplica as configurações do EF para o context
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region [ Transactions ]
            modelBuilder.ApplyConfiguration(new DailyTransactionHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionEntryConfiguration());
            #endregion

            #region [ Types ]
            modelBuilder.ApplyConfiguration(new TransactionTypeConfiguration());
            #endregion

            SeedData.Seed(modelBuilder);
        }
    }
}
