using MediatR;
using WebAPI1.Models;

namespace WebAPI1.Events.BatchNumbersGenrated
{
    public class BatchNumbersGenratedEvent : INotification
    {
        public Batch Batch { get; set; }
    }
}
