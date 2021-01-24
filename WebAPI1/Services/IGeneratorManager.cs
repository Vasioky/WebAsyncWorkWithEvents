using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI1.Models;

namespace WebAPI1.Services
{
    public interface IGeneratorManager
    {
        Task GetNumbers(Batch batch, int howMany);
    }
}
