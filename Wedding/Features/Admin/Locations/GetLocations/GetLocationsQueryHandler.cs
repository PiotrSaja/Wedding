using BuildingBlocks.CQRS;
using Wedding.Api.Repositories;

namespace Wedding.Api.Features.Admin.Locations.GetLocations
{
    public class GetLocationsQueryHandler(ILocationRepository locationRepository) : IQueryHandler<GetLocationsQuery, GetLocationsResult>
    {
        protected ILocationRepository LocationRepository { get; } = locationRepository;
        public async Task<GetLocationsResult> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
        {
            var locations = await LocationRepository.GetLocationsByUserId("3");
            throw new NotImplementedException();
        }
    }
}
