using MediatR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebAPI1.Hubs;

namespace WebAPI1.Events.EndProcessingBatch.Handlers
{
    public class ClientNotifyHandler : INotificationHandler<EndProcessingBatchEvent>
    {
        private readonly IHubContext<WorkHub> hub;

        public ClientNotifyHandler(IHubContext<WorkHub> hub)
        {
            this.hub = hub;
        }
        public Task Handle(EndProcessingBatchEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("ClientNotifyHandler EndProcessingBatchEvent");
            return hub.Clients.All.SendAsync("workprogress", notification.Batch);
        }

    }
}
