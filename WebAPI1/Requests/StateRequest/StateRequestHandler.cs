using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAPI1.Models;

namespace WebAPI1.Requests.StateRequest
{
    public class StateRequestHandler : IRequestHandler<StateRequest, Work>
    {
        private readonly AppDbContext appDbContext;

        public StateRequestHandler(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public Task<Work> Handle(StateRequest request, CancellationToken cancellationToken)
        {
            return appDbContext.Works.Include(x => x.Batches).FirstOrDefaultAsync(x => x.Id == request.WorkId);
        }
    }
}
