using BuildingBlocks.Data;
using Identity.Api.Repositories;
using Wedding.Api.Data;
using Wedding.Api.Data.Models;

namespace Wedding.Api.Repositories
{
    public interface INotificationRepository : IAsyncRepository<Notification>
    {
    }
    public class NotificationRepository(ApplicationContext context) : AsyncRepository<Notification>(context), INotificationRepository
    {
    }
}
