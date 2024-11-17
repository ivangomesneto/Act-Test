using CashFlow.Application.Interfaces.Histories;
using CashFlow.Application.Interfaces.Transactions;
using CashFlow.Application.Interfaces.Types;
using CashFlow.Infrastructure.Database.Repositories.Histories;
using CashFlow.Infrastructure.Database.Repositories.Transactions;
using CashFlow.Infrastructure.Database.Repositories.Types;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure
{
    public static class DependencyInjection
    {
        //DI dos repositórios criados
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            #region [ Transactions ]
            services.AddScoped<ITransactionEntryRepository, TransactionEntryRepository>();
            #endregion

            #region [ Histories ]
            services.AddScoped<IDailyTransactionHistoryRepository, DailyTransactionHistoryRepository>();
            #endregion

            #region [ Types ]
            services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();
            #endregion

            return services;
        }

        //DI de serviços externos
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
