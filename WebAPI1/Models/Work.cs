using System.Collections.Generic;

namespace WebAPI1.Models
{
    public class Work : BaseEntity
    {
        public int X { get; set; }
        public int Y { get; set; }
        public List<Batch> Batches { get; set; } = new List<Batch>();

        public WorkStatus Status { get; set; }
    }
}
