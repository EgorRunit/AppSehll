using System.Text.Json.Serialization;

namespace Ovotan.Shell.RabbitMQ.Models
{
    public class Queue
    {
        /// <summary>
        /// get,set - The name of the queue.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// get,set - The name of the virtual host.
        /// </summary>
        public string Vhost { get; set; }
        /// <summary>
        /// get,set - The type of the queue.
        /// </summary>
        public QueueType Type { get; set; }
        /// <summary>
        /// get,set - The status of the queue.
        /// </summary>
        public QueueState State { get; set; }
        /// <summary>
        /// get,set - The value of the auto_delete argument.
        /// </summary>
        public bool AutoDelete { get; set; }
        /// <summary>
        /// get,set - The value of the durable argument.
        /// </summary>
        public bool Durable { get; set; }
        /// <summary>
        /// get,set - The value of the exclusive argument.
        /// </summary>
        public bool Exclusive { get; set; }
        /// <summary>
        /// get,set - The total number of messages in the queue.
        /// </summary>
        public int Messages { get; set; }
        /// <summary>
        /// get,set - The number of messages ready to be delivered in the queue.
        /// </summary>
        public int MessagesReady { get; set; }
        /// <summary>
        /// get,set - The number of messages waiting for acknowledgement in the queue.
        /// </summary>
        public int MessagesUnacknowledged { get; set; }

//node Depending on the type of the queue, this is the node which holds the queue or hosts the leader.
//arguments The arguments of the queue.

    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum QueueState
    {
        Running,
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum QueueType
    {
        DefualtForVirtualHost,
        Classic,
        Quorum,
        Stream
    }
}
