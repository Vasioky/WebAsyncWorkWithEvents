using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebAPI1.Services;

namespace WebAPI1.Events.StartProcessingBatch.Handler
{
    public class StartProcessingBatchHandler : IRequestHandler<StartProcessingBatchEvent>
    {
        private readonly IGeneratorManager generatorManager;

        public StartProcessingBatchHandler(IGeneratorManager generatorManager)
        {
            this.generatorManager = generatorManager;
        }

        public async Task<Unit> Handle(StartProcessingBatchEvent request, CancellationToken cancellationToken)
        {
            await generatorManager.GetNumbers(request.Batch, request.BatchSize);

            return Unit.Value;
        }
    }
}
