using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Ovotan.Shell.RabbitMQ.Models
{
    public class Queue
    {
        /// <summary>
        /// Название очереди.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Тип очереди.
        /// </summary>
        public QueueType Type { get; set; }
        /// <summary>
        /// Сотояние очереди.
        /// </summary>
        public QueueState State { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum QueueState
    {
        Running,
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum QueueType
    {
        Classic
    }
}
