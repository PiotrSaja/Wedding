using Wedding.Api.Data.Models.Base;

namespace Wedding.Api.Data.Models
{
    public class Notification : BaseEntity
    {
        public string Message { get; set; }
        public DateTime ScheduledTime { get; set; }
        public bool IsActive { get; set; }
    }
}
