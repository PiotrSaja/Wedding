using Carter;
using MediatR;

namespace Wedding.Api.Features.Admin.Locations.GetLocations
{
    public class GetLocationsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/locations", async ([AsParameters] GetLocationsQuery query, ISender sender) =>
                {
                    var result = await sender.Send(query);

                    return Results.Ok(result);
                })
                .RequireAuthorization()
                .WithName("GetLocations")
                .Produces<GetLocationsResult>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get Locations")
                .WithDescription("Get Locations");
        }
    }
}
