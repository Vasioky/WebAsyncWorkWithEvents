using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAPI1.Events.StartProcessingBatch;
using WebAPI1.Models;

namespace WebAPI1.Services
{
    public class ProcessService : BackgroundService
    {
        private readonly IServiceProvider provider;

        public ProcessService(IServiceProvider provider)
        {
            this.provider = provider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var scope = provider.CreateScope();
                var dbCotext = scope.ServiceProvider.GetService<AppDbContext>();
                var work = dbCotext.Works.Include(x => x.Batches).FirstOrDefault(x => x.Status == WorkStatus.New);
                if (work == null)
                {
                    await Task.Delay(1000);
                    continue;
                }

                work.Status = WorkStatus.InProgress;

                var tasks = dbCotext.SaveChangesAsync();
               

                var mediator = scope.ServiceProvider.GetService<IMediator>();

                foreach (var item in work.Batches)
                {
                    await mediator.Send(new StartProcessingBatchEvent
                    {
                        Batch = item,
                        BatchSize = work.Y
                    });
                }
                await tasks;
            }
        }
    }
}
