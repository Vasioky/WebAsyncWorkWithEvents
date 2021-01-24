using MediatR;
using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Threading.Tasks;
using WebAPI1.Hubs;

namespace WebAPI1.Events.BatchNumbersGenrated.Handlers
{
    public class NotifyClientHandler : INotificationHandler<BatchNumbersGenratedEvent>
    {
        private readonly IHubContext<WorkHub> hub;

        public NotifyClientHandler(IHubContext<WorkHub> hub)
        {
            this.hub = hub;
        }

        public async Task Handle(BatchNumbersGenratedEvent notification, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("NotifyClientHandler");
            await hub.Clients.All.SendAsync("workprogress", notification.Batch);
        }
    }
}
