using MediatR;
using WebAPI1.Models;

namespace WebAPI1.Events.StartProcessing
{
    public class StartProcessingEvent : IRequest<Work>
    {
        public Work Work { get; set; }
    }
}
