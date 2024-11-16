using Serilog;

namespace CashFlow.WebApi.Configurations
{
    public static class LoggingConfiguration
    {
        public static IServiceCollection AddLoggingConfig(this IServiceCollection services)
        {
            services.AddSerilog(config =>
            {
                config.ReadFrom.Configuration(SettingsConfiguration.Configuration);
            });

            return services;
        }

        public static WebApplication UseLogRequestLoggingConfig(this WebApplication app)
        {
            app.UseSerilogRequestLogging(options =>
            {
                // Attach additional properties to the request completion event
                options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
                {
                    httpContext.Request.Body.Seek(0, SeekOrigin.Begin);
                    string requestBody = new StreamReader(httpContext.Request.Body).ReadToEndAsync().Result;
                    if (!string.IsNullOrEmpty(requestBody))
                        diagnosticContext.Set("RequestBody", string.Concat(" ", requestBody));
                };
            });

            return app;
        }
    }
}
