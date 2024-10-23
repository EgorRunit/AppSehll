using Ovotan.Shell.RabbitMQ.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Ovotan.Shell.RabbitMQ.Api
{
    public class RabbitMQApiHttpClient : RabbitMQApiHttpClientBase
    {
        HttpClient _httpClient;
        JsonSerializerOptions _jsonSerializerOptions;

        public QueueApi QueueApi { get; private set; }

        public ConnectionApi ConnectionApi { get; private set; }

        internal RabbitMQApiHttpClient(HttpClient httpClient) 
            : base(httpClient)
        {
            QueueApi = new QueueApi(httpClient);
            ConnectionApi = new ConnectionApi(httpClient);
        }

        public static async Task<RabbitMQApiHttpClient> Connect(string userName, string userPassword, string baseUri)
        {
            // Set MQ server credentials
            NetworkCredential networkCredential = new NetworkCredential(userName, userPassword);
            HttpClientHandler httpClientHandler = new HttpClientHandler { Credentials = networkCredential };
            HttpClient httpClient = new HttpClient(httpClientHandler);
            httpClient.Timeout = new TimeSpan(0, 0, 5);
            httpClient.BaseAddress = new Uri(baseUri);


            // Get the response from the API endpoint.
            try
            {
                var cancellationTokenSource = new CancellationTokenSource(new TimeSpan(0, 0, 5));

                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("api/whoami", cancellationTokenSource.Token).ConfigureAwait(false);
                if (httpResponseMessage.StatusCode != HttpStatusCode.Unauthorized)
                {


                    HttpContent httpContent = httpResponseMessage.Content;
                    using StreamReader streamReader = new StreamReader(await httpContent.ReadAsStreamAsync());
                    string returnedJsonString = await streamReader.ReadToEndAsync();
                    var serializeOptions = new JsonSerializerOptions
                    {
                        //Converters = new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, false),
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        PropertyNameCaseInsensitive = true,
                    };
                    var whoIAm = JsonSerializer.Deserialize<CurrentlyAuthenticatedUser>(returnedJsonString, serializeOptions);
                    var client = new RabbitMQApiHttpClient(httpClient);
                    client._httpClient = httpClient;
                    client._jsonSerializerOptions = serializeOptions;
                    return client;
                }
            }
            catch (Exception ex)
            {
            }
            return null;

        }
    }
}
