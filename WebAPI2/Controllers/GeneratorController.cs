using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneratorController : ControllerBase
    {
        static Random rand = new Random();
        static Random rand2 = new Random();
        [HttpGet]
        public async Task<int[]> Generate(int len)
        {
            var result = new List<int>(len);
            await foreach (var item in RangeAsync(len))
            {
                result.Add(item);
            }
            return result.ToArray();
        }

        static async IAsyncEnumerable<int> RangeAsync(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var delay = rand.Next(5, 10);
                var number = rand2.Next(1, 100);
                await Task.Delay(delay);
                yield return number;
            }
        }
    }
}
