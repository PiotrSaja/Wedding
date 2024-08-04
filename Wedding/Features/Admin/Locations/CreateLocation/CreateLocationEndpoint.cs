using BuildingBlocks.CQRS;
using Carter;
using MediatR;
using System.Security.Claims;

namespace Wedding.Api.Features.Admin.Locations.CreateLocation
{
    public record CreateLocationRequest(string Name, string Description, double Latitude, double Longitude);
    public class CreateLocationEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/locations",
                    async (HttpContext httpContext, CreateLocationRequest request, ISender sender) =>
                    {
                        var userId = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                        if (userId is null)
                            return Results.BadRequest();

                        var command = new CreateLocationCommand()
                        {
                            Name = request.Name,
                            Description = request.Description,
                            Latitude = request.Latitude,
                            Longitude = request.Longitude,
                            UserId = userId
                        };

                        var result = await sender.Send(command);

                        return Results.Ok(result);

                    })
                .RequireAuthorization()
                .WithName("CreateLocation")
                .Produces<int>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Create Location")
                .WithDescription("Create Location");
        }
    }
}
