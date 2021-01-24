using System.Linq;
using System.Threading.Tasks;
using WebAPI1.Models;

namespace WebAPI1.Services
{
    public class Processor : IProcessor
    {
        private readonly AppDbContext appDbContext;

        public Processor(
            AppDbContext appDbContext
            )
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Work> Start(Work work)
        {
            var numberOfItemsPerBatches = work.Y;
            work.Batches = Enumerable.Range(0, work.X).Select(x => new Batch
            {
                Items = Enumerable.Repeat(0, numberOfItemsPerBatches)
            }).ToList();
            appDbContext.Works.Add(work);

            await appDbContext.SaveChangesAsync();

            return work;
        }
    }
}