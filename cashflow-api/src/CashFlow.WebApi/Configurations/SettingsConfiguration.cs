namespace CashFlow.WebApi.Configurations
{
    public static class SettingsConfiguration
    {
        static string envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")!;

        static readonly IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
            .AddJsonFile("appsettings.json", false)
            .AddJsonFile($"appsettings.{envName}.json", true)
            .AddEnvironmentVariables()
            .Build();

        public static string ReadFromAppSettings(string value)
        {
            string connectionString = configuration.GetValue<string>(value)!;
            return connectionString;
        }

        public static IConfiguration Configuration => configuration;
    }
}
