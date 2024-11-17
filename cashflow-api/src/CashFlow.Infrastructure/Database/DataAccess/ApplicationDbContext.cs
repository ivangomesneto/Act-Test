using CashFlow.Infrastructure.Database.Configurations.Histories;
using CashFlow.Infrastructure.Database.Configurations.Transactions;
using CashFlow.Infrastructure.Database.Configurations.Types;
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
            modelBuilder.ApplyConfiguration(new TransactionEntryConfiguration());
            #endregion

            #region [ Histories ]
            modelBuilder.ApplyConfiguration(new DailyTransactionHistoryConfiguration());
            #endregion

            #region [ Types ]
            modelBuilder.ApplyConfiguration(new TransactionTypeConfiguration());
            #endregion

            SeedData.Seed(modelBuilder);
        }
    }
}
