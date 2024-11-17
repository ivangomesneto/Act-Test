using CashFlow.WebApi.Handlers.Histories.GenerateDailyTransactionHistory;
using CashFlow.WebApi.Handlers.Histories.GetAllDailyTransactionHistories;
using CashFlow.WebApi.Handlers.Transactions.AddTransactionEntry;
using CashFlow.WebApi.Handlers.Transactions.DeleteTransactionEntry;
using CashFlow.WebApi.Handlers.Transactions.GetAllTransactionEntries;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CashFlow.WebApi.Configurations
{
    public static class RoutesConfiguration
    {
        public static void AddRoutesMapsConfig(this IEndpointRouteBuilder app)
        {
            #region [ Health ]

            app.MapGet("health",
            [SwaggerOperation(Summary = "Get health of api")]
            [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
            () =>
            {
                return "OK";
            }).WithTags("Health").AllowAnonymous().WithOpenApi();

            #endregion

            #region [ Transactions ]

            app.MapPost("transactions",
            [SwaggerOperation(Summary = "Add a new transaction entry")]
            [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AddTransactionEntryResponse))]
            (IAddTransactionEntryHandler handler, [FromBody] AddTransactionEntryRequest request) =>
            {
                return handler.AddTransactionEntry(request);
            }).WithTags("Transactions").AllowAnonymous().WithOpenApi();

            app.MapDelete("transactions/{id}",
            [SwaggerOperation(Summary = "Delete transaction entry")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            (IDeleteTransactionEntryHandler handler, Guid id) =>
            {
                return handler.DeleteTransactionEntry(id);
            }).WithTags("Transactions").AllowAnonymous().WithOpenApi();

            app.MapGet("transactions",
            [SwaggerOperation(Summary = "Get all transactions")]
            [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAllTransactionEntriesResponse))]
            (IGetAllTransactionEntriesHandler handler, [FromQuery] DateTime? date = null, [FromQuery, SwaggerParameter(Description = "initialbalance | credit | debit")] string? typeTransactionId = null) =>
            {
                return handler.GetTransactionEntries(date, typeTransactionId);
            }).WithTags("Transactions").AllowAnonymous().WithOpenApi();

            #endregion

            #region [ Histories ]

            app.MapPost("summaries",
            [SwaggerOperation(Summary = "Generate a daily transactions summary")]
            [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GenerateDailyTransactionHistoryResponse))]
            (IGenerateDailyTransactionHistoryHandler handler, [FromBody] GenerateDailyTransactionHistoryRequest request) =>
            {
                return handler.GenerateDailyTransactionHistory(request);
            }).WithTags("Summaries").AllowAnonymous().WithOpenApi();

            app.MapGet("summaries",
            [SwaggerOperation(Summary = "Get all daily transactions summary")]
            [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAllTransactionEntriesResponse))]
            (IGetAllDailyTransactionHistoriesHandler handler, [FromQuery] DateTime? date = null) =>
            {
                return handler.GetAllDailyTransactionHistories(date);
            }).WithTags("Summaries").AllowAnonymous().WithOpenApi();

            #endregion
        }
    }
}
