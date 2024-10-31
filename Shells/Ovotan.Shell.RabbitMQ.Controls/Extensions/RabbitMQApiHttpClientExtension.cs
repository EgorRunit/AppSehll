using Ovotan.Shell.RabbitMQ.Api;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ovotan.Shell.RabbitMQ.Controls
{
    internal static class RabbitMQApiHttpClientExtension
    {
        internal static IModel GetChannel(this RabbitMQApiHttpClient client )
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = client.HostName,
                
                UserName = client.UserName,
                Password = client.UserPassword
            };
            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();

            return channel;
        }
    }
}
