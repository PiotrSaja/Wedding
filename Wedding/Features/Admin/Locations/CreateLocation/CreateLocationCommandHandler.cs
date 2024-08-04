using BuildingBlocks.CQRS;
using Wedding.Api.Data.Models;
using Wedding.Api.Repositories;

namespace Wedding.Api.Features.Admin.Locations.CreateLocation
{
    internal class CreateLocationCommandHandler(ILocationRepository locationRepository)
        : ICommandHandler<CreateLocationCommand, int>
    {
        protected ILocationRepository LocationRepository { get; } = locationRepository;

        public async Task<int> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var location = new Location()
            {
                Name = request.Name,
                Description = request.Description,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                UserId = request.UserId
            }; // to enrich model

            await LocationRepository.Add(location);

            return location.Id;
        }
    }
}
