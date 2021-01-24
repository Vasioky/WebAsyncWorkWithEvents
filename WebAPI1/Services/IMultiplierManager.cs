using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI1.Models;

namespace WebAPI1.Services
{
    public interface IMultiplierManager
    {
        Task Multipaly(Batch batch);
    }
}