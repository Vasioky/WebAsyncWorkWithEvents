using System.Threading.Tasks;
using WebAPI1.Models;

namespace WebAPI1.Services
{
    public interface IProcessor
    {
        Task<Work> Start(Work work);
    }
}
