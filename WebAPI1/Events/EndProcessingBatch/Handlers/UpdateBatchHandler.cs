using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAPI1.Models;

namespace WebAPI1.Events.EndProcessingBatch.Handlers
{
    public class UpdateBatchHandler : INotificationHandler<EndProcessingBatchEvent>
    {
        private readonly AppDbContext appDbContext;

        public UpdateBatchHandler(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task Handle(EndProcessingBatchEvent notification, CancellationToken cancellationToken)
        {
            var work = await appDbContext.Works.Include(x => x.Batches).FirstOrDefaultAsync(x => x.Batches.Contains(notification.Batch));
            if (work != null && work.Batches.All(x => x.Result != null))
            {
                work.Status = WorkStatus.Completed;
            }
            await appDbContext.SaveChangesAsync();
        }
    }
}
