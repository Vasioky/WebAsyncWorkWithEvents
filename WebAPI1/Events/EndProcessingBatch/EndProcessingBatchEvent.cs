using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI1.Models;

namespace WebAPI1.Events.EndProcessingBatch
{
    public class EndProcessingBatchEvent : INotification 
    {
        public Batch Batch { get; set; }
    }
}
