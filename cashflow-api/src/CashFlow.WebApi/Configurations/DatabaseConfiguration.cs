using CashFlow.Infrastructure.Database.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.WebApi.Configurations
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDatabaseConfig(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseMySQL(SettingsConfiguration.ReadFromAppSettings("PersistenceModule:MySQLConnection"));
            });

            services.AddScoped<DbContext, ApplicationDbContext>();

            return services;
        }

        public static WebApplication UseMigrationsConfig(this WebApplication app)
        {
            //Execute all migrations
            using (var scope = app.Services.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dataContext.Database.Migrate();
            }

            return app;
        }
    }
}
