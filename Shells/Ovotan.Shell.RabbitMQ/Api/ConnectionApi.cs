using Ovotan.Shell.RabbitMQ.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ovotan.Shell.RabbitMQ.Api
{
    public class ConnectionApi : RabbitMQApiHttpClientBase
    {
        internal ConnectionApi(HttpClient httpClient) : base(httpClient) 
        { 
        }

        public async Task<List<Connection>> GetConnections()
        {
            return await GetData<List<Connection>>("/api/connections");
        }
    }
}
