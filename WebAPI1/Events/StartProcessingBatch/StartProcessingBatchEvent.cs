using MediatR;
using WebAPI1.Models;

namespace WebAPI1.Events.StartProcessingBatch
{
    public class StartProcessingBatchEvent : IRequest
    {
        public Batch Batch  { get; set; }

        public int BatchSize { get; set; }
    }
}
