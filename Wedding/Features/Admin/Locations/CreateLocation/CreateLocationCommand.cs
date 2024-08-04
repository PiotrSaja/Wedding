using BuildingBlocks.CQRS;

namespace Wedding.Api.Features.Admin.Locations.CreateLocation
{
    public class CreateLocationCommand : ICommand<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string UserId { get; set; }
    }
}
