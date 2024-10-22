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
using Ovotan.Controls.Docking.Messages;
using Ovotan.Controls.Docking.Enums;
using Ovotan.ApplicationShell.Controls.ToolbarElements;

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
            _shellDockPanelToolbarElements = new List <IShellToolbarElement> ();
            _shellDockPanelToolbarElements.Add(new ToolbarElementBase() {Type = ShellToolbarElementType.Button, Text="+", Action=_createConnection });
            _shellDockPanelToolbarElements.Add(new AddGroupFolder());
            ObjectBrowser = new ShellObjectBrowser(this);
        }

        public void Start(IDockingMessageQueue dockingMessageQueue)
        {
            _dockingMessageQueue = dockingMessageQueue;
            var message = new PanelAttachedMessage()
            {
                DockPanelContent = ObjectBrowser,
                Type = PanelAttachedType.Left
            };
            _dockingMessageQueue.Publish(DockingMessageType.PanelAttached, message);
            
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
