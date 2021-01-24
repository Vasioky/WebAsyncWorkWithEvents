using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI1.Models;

namespace WebAPI1.Requests.StateRequest
{
    public class StateRequest : IRequest<Work>
    {
        public int WorkId { get; set; }
    }
}
