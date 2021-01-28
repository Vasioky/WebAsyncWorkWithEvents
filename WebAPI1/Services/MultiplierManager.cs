using MediatR;
using System;
using System.Threading.Tasks;
using WebAPI1.Events.EndProcessingBatch;
using WebAPI1.Models;

namespace WebAPI1.Services
{
    public class MultiplierManager : IMultiplierManager
    {
        private readonly IMediator mediator;

        public MultiplierManager(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Multipaly(Batch batch)
        {
            if (batch == null)
            {
                throw new ArgumentNullException(nameof(batch));
            }
            
            var result = 1;
            
            foreach (var item in batch.Items)
            {
                result *= item;
                Console.WriteLine($"{result}");
            }
            
            batch.Result = result;
            await mediator.Publish(new EndProcessingBatchEvent
            {
                Batch = batch
            });
        }
    }
}
