using Ovotan.ApplicationShell.Controls.Interfaces;
using System.Windows;
using Ovotan.Controls.Docking.Interfaces;
using Ovotan.ApplicationShell.Controls;
using Ovotan.Controls.Docking.Messages;
using Ovotan.Controls.Docking.Enums;
using Ovotan.ApplicationShell.Controls.ToolbarElements;
using Ovotan.Shell.RabbitMQ.Controls.DockPanels;
using System.Windows.Input;
using Ovotan.Windows.Common.Controls;
using Ovotan.ApplicationShell.Controls.Dialogs;
using System.Windows.Controls;

namespace Ovotan.Shell.RabbitMQ.Controls
{
   

    public class RabbitMQEndPoint : EndPointManager
    {
        IDockingMessageQueue _dockingMessageQueue;

        static RabbitMQEndPoint()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RabbitMQEndPoint), new FrameworkPropertyMetadata(typeof(EndPointManager)));
        }

        public RabbitMQEndPoint() :base()
        {
            Header = "RabbitMQ Обозреватель";
            var cmd = new ButtonCommand<object>((x) =>
            {
                var ss = 5;
            });
            ToolbarActions.Add(new ToolbarButton() { Text = "+", Type = ShellToolbarElementType.Button, 
                Command = cmd});
            ToolbarActions.Add(new ToolbarButton() { Text = "++", Type = ShellToolbarElementType.Button, 
                Command = new  ButtonCommand<object>(_ => _addGroupFolder())});
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


        void _addGroupFolder()
        {
            showDialog<string>(DialogManagerType.AddGroupFolder, (folderName) =>
            {
                var selectedNode = treeView.SelectedItem as ObjectBrowserNode;
                var newNode = new ObjectBrowserNode() { Header = folderName };
                if (selectedNode != null)
                {
                    selectedNode.Items.Add(newNode);
                    selectedNode.ExpandSubtree();
                }
                else
                {
                    treeView.Items.Add(newNode);
                }
            });
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
