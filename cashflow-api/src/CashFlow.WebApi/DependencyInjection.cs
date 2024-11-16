using CashFlow.WebApi.Handlers.Transactions.AddTransactionEntry;
using CashFlow.WebApi.Handlers.Transactions.DeleteTransactionEntry;
using CashFlow.WebApi.Handlers.Transactions.GetAllTransactionEntries;

namespace CashFlow.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            #region [ Transactions ]
            services.AddScoped<IAddTransactionEntryHandler, AddTransactionEntryHandler>();
            services.AddScoped<IDeleteTransactionEntryHandler, DeleteTransactionEntryHandler>();
            services.AddScoped<IGetAllTransactionEntriesHandler, GetAllTransactionEntriesHandler>();
            #endregion

            return services;
        }
    }
}
