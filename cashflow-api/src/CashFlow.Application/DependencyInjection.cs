using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Application
{
    public static class DependencyInjection
    {
        //DI dos casos de usos criados
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            return services;
        }
    }
}
