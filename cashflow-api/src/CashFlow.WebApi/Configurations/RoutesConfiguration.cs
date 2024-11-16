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
        }
    } 
}
