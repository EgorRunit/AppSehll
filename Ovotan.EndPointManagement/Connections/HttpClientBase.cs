using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Ovotan.EndPointManagement.Connections
{
    /// <summary>
    /// Базовый класс подключения к конечной точке по Http.
    /// </summary>
    public class HttpClientBase : HttpClient
    {
        /// <summary>
        /// get,set - Название подключения к ноченой точке.
        /// </summary>
        public string ConnectionName { get; set; }
        /// <summary>
        /// get,set - Uri базового хоста используемого при подключении.
        /// </summary>
        public string BaseUrl { get; set; }
        /// <summary>
        /// get,set - Логин пользователя.
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// get,set - Пароль пользователя.
        /// </summary>
        public string UserPassword { get; set; }
        /// <summary>
        /// get,set - Экземпляр HttpClient.
        /// </summary>
        [JsonIgnore]
        protected HttpClient client { get; private set; }
        /// <summary>
        /// Экземпляр настроек для сериалиции данных в JSON используемый в методе getData<T>(string api).
        /// </summary>
        [JsonIgnore]
        protected JsonSerializerOptions jsonSerializerOptions{ get; set; }

        /// <summary>
        /// Попытка подключиться к конечной точке.
        /// </summary>
        /// <param name="baseUri">Uri базового хоста</param>
        /// <param name="uriPart">Логин пользователя.</param>
        /// <param name="userName">Пароль пользователя.</param>
        /// <param name="userPassword">Экземпляр HttpClient.</param>
        /// <returns>Кортеж с результатами подключения.</returns>
        public async Task<(bool success , string reasonPhrase)> TryConnectionAsync(string baseUri, string userName, string userPassword)
        {
            NetworkCredential networkCredential = new NetworkCredential(userName, userPassword);
            HttpClientHandler httpClientHandler = new HttpClientHandler { Credentials = networkCredential };
            HttpClient httpClient = new HttpClient(httpClientHandler);
            httpClient.Timeout = new TimeSpan(0, 0, 5);
            httpClient.BaseAddress = new Uri(baseUri);

            var cancellationTokenSource = new CancellationTokenSource(new TimeSpan(0, 0, 5));
            try
            {
                var httpResponseMessage = await httpClient.GetAsync("", cancellationTokenSource.Token).ConfigureAwait(false);
                if (httpResponseMessage.StatusCode != HttpStatusCode.Unauthorized)
                {
                    client = httpClient;
                    BaseUrl = baseUri; 
                    UserName = userName; 
                    UserPassword = userPassword;
                    return (true, string.Empty);
                }
                return (false, httpResponseMessage.ReasonPhrase);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        /// <summary>
        /// Получение данных от конечной точки.
        /// </summary>
        /// <typeparam name="T">Тип возвращаемых данных.</typeparam>
        /// <param name="api">Название вызываемого апи (baseUri + api).</param>
        /// <returns>Преобразованный json в укзанный тип T.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<T> GetData<T>(string api) where T : class
        {
            var httpResponseMessage = await client.GetAsync(api).ConfigureAwait(false);
            if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("e");
            }
            var json = await httpResponseMessage.Content.ReadAsStringAsync();
            if (jsonSerializerOptions != null)
            {
                return JsonSerializer.Deserialize<T>(json, jsonSerializerOptions);
            }
            else
            {
                return JsonSerializer.Deserialize<T>(json);
            }
        }
    }
}
