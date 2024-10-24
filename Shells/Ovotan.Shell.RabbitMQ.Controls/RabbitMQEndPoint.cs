using Ovotan.ApplicationShell.Controls.Interfaces;
using System.Windows;
using Ovotan.Controls.Docking.Interfaces;
using Ovotan.ApplicationShell.Controls;
using Ovotan.Controls.Docking.Messages;
using Ovotan.Controls.Docking.Enums;
using Ovotan.ApplicationShell.Controls.ToolbarElements;
using Ovotan.Shell.RabbitMQ.Controls.DockPanels;
using System.Windows.Input;

namespace Ovotan.Shell.RabbitMQ.Controls
{
   

    public class RabbitMQEndPoint : EndPoint
    {
        IObjectBrowser _objectBrowser;
        List<IShellToolbarElement> _shellDockPanelToolbarElements;
        IDockingMessageQueue _dockingMessageQueue;

        public IEnumerable<IShellToolbarElement> ObjectBrowserToolbarElements
        {
            get
            {
                return _shellDockPanelToolbarElements;
            }
        }

        public string Header => "RabbitMQ Management";

        static RabbitMQEndPoint()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RabbitMQEndPoint), new FrameworkPropertyMetadata(typeof(EndPoint)));
        }

        //public ShellObjectBrowser ObjectBrowser { get; private set; }

        int index = 0;
        public RabbitMQEndPoint()
        {
            _shellDockPanelToolbarElements = new List<IShellToolbarElement>();
            _shellDockPanelToolbarElements.Add(new ToolbarElementBase() { Type = ShellToolbarElementType.Button, Text = "+", Action = _createConnection });
            _shellDockPanelToolbarElements.Add(new AddGroupFolder());
            //ObjectBrowser = new ShellObjectBrowser(this);
        }


        public override void Start(IDockingMessageQueue dockingMessageQueue)
        {
            base.Start(dockingMessageQueue);
            _dockingMessageQueue = dockingMessageQueue;
            var message = new PanelAttachedMessage()
            {
                DockPanelContent = this,
                Type = PanelAttachedType.Left
            };
            _dockingMessageQueue.Publish(DockingMessageType.PanelAttached, message);
        }

        //public void Start(IDockingMessageQueue dockingMessageQueue)
        //{
        //    _dockingMessageQueue = dockingMessageQueue;
        //    var message = new PanelAttachedMessage()
        //    {
        //        DockPanelContent = this,
        //        Type = PanelAttachedType.Left
        //    };
        //    _dockingMessageQueue.Publish(DockingMessageType.PanelAttached, message);

        //}

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        void _createConnection()
        {
            _dockingMessageQueue.Publish(DockingMessageType.ShowDockPanelWindow, new ConnectionManagement());

            //var wnd = new ConnectionManagement();// ("localhost");

            //    //wnd.Owner = Application.Current.MainWindow;
            //    wnd.Visibility = Visibility.Visible;
            //    wnd.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            //    //var wnd = new ConnectDialog();
            //    wnd.Show();


            //    return;
            //    var factory = new ConnectionFactory() { HostName = "localhost" };






            //    using var connection = factory.CreateConnection();
            //    //factory.CreateConnection()


            //    using var channel = connection.CreateModel();
            //    channel.QueueDeclare(
            //            queue: "hello",
            //             durable: false,
            //             exclusive: false,
            //    autoDelete: false,

            //    arguments: null);

            //    var consumer = new EventingBasicConsumer(channel);
            //    consumer.Received += (ch, ea) =>
            //    {
            //        var content = Encoding.UTF8.GetString(ea.Body.ToArray());
            //        if (index == 0)
            //        {
            //            index++;
            //            channel.BasicReject(1, false);// .BasicNack(1, false, false);
            //            //channel.BasicAck(ea.DeliveryTag, false);
            //        };
            //    };

            //    channel.BasicConsume("hello", false, consumer);

            //    const string message = "Hello World!22werwerewrwerewrewrew22";
            //    var body = Encoding.UTF8.GetBytes(message);

            //    var prop = channel.CreateBasicProperties();
            //    prop.DeliveryMode = 2;
            //    channel.BasicPublish(exchange: string.Empty,
            //                         routingKey: "hello",
            //                         basicProperties: prop,

            //                         body: body);
        }
    }
}
