using CashFlow.Application.UseCases.AddTransactionEntry;
using CashFlow.Application.UseCases.DeleteTransactionEntry;
using CashFlow.Application.UseCases.GetAllTransactionEntries;
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

            return services;
        }
    }
}
