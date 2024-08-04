using BuildingBlocks.CQRS;

namespace Wedding.Api.Features.Admin.Locations.GetLocations
{
    public record GetLocationsQuery(int PageNumber = 1, int PageSize = 10) : IQuery<GetLocationsResult>;

}
