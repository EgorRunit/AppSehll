using Ovotan.EndPointManagement.Connections;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;

namespace Ovotan.Shell.RabbitMQ.Api
{
    public class RabbitMQApiHttpClient : HttpClientBase
    {
        public QueueApi QueueApi { get; private set; }

        public ConnectionApi ConnectionApi { get; private set; }

        public RabbitMQApiHttpClient()
        {
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                PropertyNameCaseInsensitive = true,
            };
            jsonSerializerOptions.Converters.Add(new DDD());
            QueueApi = new QueueApi(this);
            ConnectionApi = new ConnectionApi(this);
        }
    }

    public class DDD : JsonConverter<DateTime>
    {
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
        }
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var stringValue = reader.GetInt64();
            return DateTimeOffset.FromUnixTimeMilliseconds(stringValue).DateTime;
        }
    }

//    CamelCase First word starts with a lower case character.
//Successive words start with an uppercase character.TempCelsius tempCelsius
//KebabCaseLower* Words are separated by hyphens.
//All characters are lowercase.TempCelsius temp-celsius
//KebabCaseUpper*	Words are separated by hyphens.
//All characters are uppercase.	TempCelsius TEMP-CELSIUS
//SnakeCaseLower*	Words are separated by underscores.
//All characters are lowercase.	TempCelsius temp_celsius
//SnakeCaseUpper* Words are separated by underscores.
//All characters are uppercase.	TempCelsius TEMP_CELSIUS
}
