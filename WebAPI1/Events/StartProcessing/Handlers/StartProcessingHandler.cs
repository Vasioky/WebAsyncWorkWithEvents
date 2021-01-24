using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAPI1.Models;
using WebAPI1.Services;

namespace WebAPI1.Events.StartProcessing.Handlers
{
    public class StartProcessingHandler : IRequestHandler<StartProcessingEvent, Work>
    {
        private readonly IProcessor processor;

        public StartProcessingHandler(IProcessor processor)
        {
            this.processor = processor;
        }

        public async Task<Work> Handle(StartProcessingEvent request, CancellationToken cancellationToken)
        {
            return await processor.Start(request.Work);
        }
    }
}
