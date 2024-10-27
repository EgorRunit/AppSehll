using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ovotan.Shell.RabbitMQ.Api
{
    public class QueueApi
    {
        RabbitMQApiHttpClient _client;

        public QueueApi(RabbitMQApiHttpClient client) 
        {
            _client = client;
        }

        public async Task<List<Models.Queue>> GetQueuesAsync()
        {
            return await _client.GetData<List<Models.Queue>>("api/queues");
        }
    }
}
