using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ovotan.Shell.RabbitMQ.Api
{
    public class QueueApi : RabbitMQApiHttpClientBase
    {
        public QueueApi(HttpClient client) 
            : base(client)
        {

        }

        public async Task<List<Models.Queue>> GetQueues()
        {
            return await GetData<List<Models.Queue>>("api/queues");
        }
    }
}
