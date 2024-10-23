using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ovotan.Shell.RabbitMQ.Api
{
    public class RabbitMQApiHttpClientBase
    {
        protected HttpClient client;
        protected JsonSerializerOptions options;

        protected RabbitMQApiHttpClientBase(HttpClient client)
        {
            this.client = client;
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        protected internal async Task<T> GetData<T>(string api) where T : class
        {
            var httpResponseMessage = await client.GetAsync(api).ConfigureAwait(false);
            if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("e");
            }
            var json = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(json, options);
        }

    }
}
