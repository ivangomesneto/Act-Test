using Microsoft.OpenApi.Models;
using System.Diagnostics;
using System.Reflection;

namespace CashFlow.WebApi.Configurations
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

            services.AddSwaggerGen(s =>
            {
                s.EnableAnnotations();
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = fvi.ProductVersion,
                    Title = "CashFlow",
                    Description = $"API CashFlow",
                    Contact = new OpenApiContact
                    {
                        Name = "TI CashFlow"
                    },
                    TermsOfService = null,
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        public static WebApplication UseSwaggerConfig(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                var swaggerEndpoint = $"/swagger/v1/swagger.json";
                options.SwaggerEndpoint(swaggerEndpoint, "v1");
                options.DisplayRequestDuration();
            });

            return app;
        }
    }
}
