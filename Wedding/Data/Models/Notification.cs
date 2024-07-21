using BuildingBlocks.Data;

namespace Wedding.Api.Data.Models
{
    public class Notification : IEntity
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime ScheduledTime { get; set; }
    }
}
