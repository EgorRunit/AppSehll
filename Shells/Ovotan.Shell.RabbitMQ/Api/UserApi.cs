using Ovotan.Shell.RabbitMQ.Models;
using System.Threading.Tasks;

namespace Ovotan.Shell.RabbitMQ.Api
{
    public class UserApi 
    {
        RabbitMQApiHttpClient _client;

        internal UserApi(RabbitMQApiHttpClient client)
        {
            _client = client;
        }

        public async Task<CurrentlyAuthenticatedUser> GetCurrentlyAuthenticatedUserAsync()
        {
            return await _client.GetData<CurrentlyAuthenticatedUser>("api/queues");
        }

    }
}
