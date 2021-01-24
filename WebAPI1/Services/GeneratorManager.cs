using MediatR;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPI1.Events.BatchNumbersGenrated;
using WebAPI1.Models;

namespace WebAPI1.Services
{
    public class GeneratorManager : IGeneratorManager
    {
        private readonly HttpClient httpClient;
        private readonly IMediator mediator;
        private readonly string url = "http://localhost:5003/api/generator";
        public GeneratorManager(HttpClient httpClient, IMediator mediator)
        {
            this.httpClient = httpClient;
            this.mediator = mediator;
        }
        public async Task GetNumbers(Batch batch, int howMany)
        {
            var resp = await httpClient.GetAsync($"{url}?len={howMany}");

            resp.EnsureSuccessStatusCode();

            batch.Items = JsonSerializer.Deserialize<int[]>(await resp.Content.ReadAsStringAsync());

            await mediator.Publish(new BatchNumbersGenratedEvent
            {
                Batch = batch
            });
        }

    }
}
