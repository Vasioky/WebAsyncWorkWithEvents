using MediatR;
using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Threading.Tasks;
using WebAPI1.Hubs;
using WebAPI1.Models;
using WebAPI1.Services;

namespace WebAPI1.Events.BatchNumbersGenrated.Handlers
{
    public class BatchNumbersMultiplyHandler : INotificationHandler<BatchNumbersGenratedEvent>
    {
        private readonly IMultiplierManager multiplierManager;

        public BatchNumbersMultiplyHandler(IMultiplierManager multiplierManager)
        {
            this.multiplierManager = multiplierManager;
        }

        public async Task Handle(BatchNumbersGenratedEvent notification, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("BatchNumbersMultiplyHandler");
            await multiplierManager.Multipaly(notification.Batch);
        }
    }
}
