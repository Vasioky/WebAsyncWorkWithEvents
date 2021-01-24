using MediatR;
using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Threading.Tasks;
using WebAPI1.Hubs;
using WebAPI1.Models;
using WebAPI1.Services;

namespace WebAPI1.Events.BatchNumbersGenrated.Handlers
{
    public class UpdateBatchHandler : INotificationHandler<BatchNumbersGenratedEvent>
    {
        private readonly AppDbContext appDbContext;

        public UpdateBatchHandler(
            AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task Handle(BatchNumbersGenratedEvent notification, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("UpdateBatchHandler");
            await appDbContext.SaveChangesAsync();
        }
    }
}
