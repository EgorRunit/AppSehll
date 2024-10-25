using Ovotan.ApplicationShell.Controls.Interfaces;
using System.Windows;
using Ovotan.Controls.Docking.Interfaces;
using Ovotan.ApplicationShell.Controls;
using Ovotan.Controls.Docking.Messages;
using Ovotan.Controls.Docking.Enums;
using Ovotan.ApplicationShell.Controls.ToolbarElements;
using Ovotan.Shell.RabbitMQ.Controls.DockPanels;
using Ovotan.Windows.Common.Controls;
using Ovotan.ApplicationShell.Controls.Configurations;
using Ovotan.Shell.RabbitMQ.Controls.Configurations;
using Ovotan.ApplicationShell.Controls.Enums;
using Ovotan.Shell.RabbitMQ.Controls.Doalogs;
using Ovotan.Shell.RabbitMQ.Controls.Models;

namespace Ovotan.Shell.RabbitMQ.Controls
{
    public class RabbitMQEndPoint : EndPointManager
    {
        static RabbitMQEndPoint()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RabbitMQEndPoint), new FrameworkPropertyMetadata(typeof(EndPointManager)));
        }

        public RabbitMQEndPoint() : base()
        {

            Header = "RabbitMQ Обозреватель";
            ToolbarActions.Add(new ToolbarButton() { 
                Text = "+", 
                Type = ShellToolbarElementType.Button,
                Command = new ButtonCommand<object>(_ => _addGroupFolder())
            });
            ToolbarActions.Add(new ToolbarButton()
            {
                Text = "++",
                Type = ShellToolbarElementType.Button,
                Command = new ButtonCommand<object>(_ => _addCreateConnection())
            });
        }


        public override void Start(EndPointConfigurations endPointConfigurations, IDockingMessageQueue dockingMessageQueue)
        {
            base.Start(endPointConfigurations, dockingMessageQueue);
            var message = new PanelAttachedMessage()
            {
                DockPanelContent = this,
                Type = PanelAttachedType.Left
            };
            dockingMessageQueue.Publish(DockingMessageType.PanelAttached, message);
        }

        public override void SaveConfiguration()
        {
            base.SaveConfiguration();
            var settings = new RabbitMQEndPointConfiguration();
            settings.ObjectBrowserTree = treeView.GetConfigurationNodes();
            endPointConfigurations.SaveEndPoint<RabbitMQEndPointConfiguration>("RabbitMQ", settings);
        }

        public override void LoadConfiguration()
        {
            base.LoadConfiguration();
            treeView.AddDataType(typeof(EndPointConnection));
            var settings = endPointConfigurations.LoadEndPoint<RabbitMQEndPointConfiguration>("RabbitMQ");
            if (settings != null)
            {
                treeView.LoadCoonfigurationNodes(settings.ObjectBrowserTree);
            }
        }

        void _addCreateConnection()
        {
            var wnd = new CreateConnectionDialog();
            if (wnd.ShowDialog() == true)
            {
                var connection = wnd.Tag as EndPointConnection;
                var selectedNode = treeView.SelectedItem as EndPointObjectBrowserTreeItem;
                var newNode = new EndPointObjectBrowserTreeItem() 
                { 
                    Header = connection.Name, 
                    Data = connection,
                    Type = EndPointObjectBrowserTreeItemType.Configuration,
                    IsLazyLoading = true,
                };
                if (selectedNode != null)
                {
                    selectedNode.Items.Add(newNode);
                    selectedNode.ExpandSubtree();
                }
                else
                {
                    treeView.Items.Add(newNode);
                }
            }
           
        }

        void _addGroupFolder()
        {
            showDialog<string>(DialogManagerType.AddGroupFolder, (folderName) =>
            {
                var selectedNode = treeView.SelectedItem as EndPointObjectBrowserTreeItem;
                var newNode = new EndPointObjectBrowserTreeItem() { Header = folderName, Type = EndPointObjectBrowserTreeItemType.Configuration };
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
            dockingMessageQueue.Publish(DockingMessageType.ShowDockPanelWindow, new ConnectionManagement());

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
