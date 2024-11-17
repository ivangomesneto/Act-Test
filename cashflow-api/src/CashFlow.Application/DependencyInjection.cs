using CashFlow.Application.UseCases.Histories.GenerateDailyTransactionHistory;
using CashFlow.Application.UseCases.Histories.GetAllDailyTransactionHistories;
using CashFlow.Application.UseCases.Transactions.AddTransactionEntry;
using CashFlow.Application.UseCases.Transactions.DeleteTransactionEntry;
using CashFlow.Application.UseCases.Transactions.GetAllTransactionEntries;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Application
{
    public static class DependencyInjection
    {
        //DI dos casos de usos criados
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            #region [ Transactions ]
            services.AddScoped<IAddTransactionEntryUseCase, AddTransactionEntryUseCase>();
            services.AddScoped<IDeleteTransactionEntryUseCase, DeleteTransactionEntryUseCase>();
            services.AddScoped<IGetAllTransactionEntriesUseCase, GetAllTransactionEntriesUseCase>();
            #endregion

            #region [ Histories ]
            services.AddScoped<IGenerateDailyTransactionHistoryUseCase, GenerateDailyTransactionHistoryUseCase>();
            services.AddScoped<IGetAllDailyTransactionHistoriesUseCase, GetAllDailyTransactionHistoriesUseCase>();
            #endregion

            return services;
        }
    }
}
