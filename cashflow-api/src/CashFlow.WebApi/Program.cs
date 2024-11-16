using CashFlow.Application;
using CashFlow.Infrastructure;
using CashFlow.WebApi;
using CashFlow.WebApi.Configurations;
using CashFlow.WebApi.Middlewares;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();
builder.Services.AddDatabaseConfig();
builder.Services.AddUseCases();
builder.Services.AddRepositories();
builder.Services.AddInfrastructureServices();
builder.Services.AddHandlers();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
});
builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
});
builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
});

builder.Services.AddLoggingConfig();

var app = builder.Build();

//app.UseMigrationsConfig();
app.UseSwaggerConfig();
app.UseMiddleware<CustomHttpContextMiddleware>();
app.UseLogRequestLoggingConfig();
app.UseHttpsRedirection();
app.AddRoutesMapsConfig();

app.Run();