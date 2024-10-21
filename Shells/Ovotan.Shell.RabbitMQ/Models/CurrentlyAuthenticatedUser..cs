using System.Text.Json.Serialization;

namespace Ovotan.Shell.RabbitMQ.Models
{
    public class CurrentlyAuthenticatedUser
    {
        public string Name { get; set; }
        public string[] Tags { get; set; }
        [JsonPropertyName("is_internal_user")]
        public bool IsInternalUser { get; set; }
    }
}
