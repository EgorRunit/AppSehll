using Ovotan.ApplicationShell.Controls.Interfaces;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using Ovotan.Controls.Docking.Interfaces;
using Ovotan.ApplicationShell.Controls;
using RabbitMQ.Client;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using RabbitMQ.Client.Events;
using System.Threading.Channels;

namespace Ovotan.Shell.RabbitMQ.Controls
{
    public class Shell : IShell
    {
        List <IShellToolbarElement> _shellDockPanelToolbarElements;
        IDockingMessageQueue _dockingMessageQueue;

        public IEnumerable<IShellToolbarElement> ObjectBrowserToolbarElements
        {
            get
            {
                return _shellDockPanelToolbarElements;
            }
        }

        public string Header => "RabbitMQ Management";

        public ShellObjectBrowser ObjectBrowser { get; private set; }

        int index = 0;
        public Shell()
        {
            //_dockingMessageQueue = dockingMessageQueue;
            _shellDockPanelToolbarElements = new List <IShellToolbarElement> ();
            _shellDockPanelToolbarElements.Add(new ShellToolbarElement(ShellToolbarElementType.Button, _createConnection));
            ObjectBrowser = new ShellObjectBrowser(this);
        }


        void _createConnection()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
           


            using var channel = connection.CreateModel();
            channel.QueueDeclare(
                    queue: "hello",
                     durable: false,
                     exclusive: false,
            autoDelete: false,
            
            arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                if (index == 0)
                {
                    index++;
                    channel.BasicReject(1, false);// .BasicNack(1, false, false);
                    //channel.BasicAck(ea.DeliveryTag, false);
                };
            };

            channel.BasicConsume("hello", false, consumer);

            const string message = "Hello World!22werwerewrwerewrewrew22";
            var body = Encoding.UTF8.GetBytes(message);

            var prop = channel.CreateBasicProperties();
            prop.DeliveryMode = 2;
            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "hello",
                                 basicProperties: prop,
                                 
                                 body: body);
        }
    }
}
