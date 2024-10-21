using Ovotan.Shell.RabbitMQ.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ovotan.Shell.RabbitMQ.Api
{
    public class UserApi : RabbitMQApiHttpClientBase
    {
        internal UserApi(HttpClient client, JsonSerializerOptions options)
            : base(client)
        {
        }

        public async Task<CurrentlyAuthenticatedUser> GetCurrentlyAuthenticatedUser()
        {
            return await GetData<CurrentlyAuthenticatedUser>("api/whoami");
        }

    }
}
