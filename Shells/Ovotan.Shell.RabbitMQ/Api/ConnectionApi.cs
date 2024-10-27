using Ovotan.Shell.RabbitMQ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ovotan.Shell.RabbitMQ.Api
{
    public class ConnectionApi
    {
        RabbitMQApiHttpClient _client;

        internal ConnectionApi(RabbitMQApiHttpClient httpClient)
        { 
            _client = httpClient;
        }

        public async Task<List<ConnectionListItem>> GetConnectionsAsync()
        {
            return await _client.GetData<List<ConnectionListItem>>("/api/connections").ConfigureAwait(false);
        }
    }
}
