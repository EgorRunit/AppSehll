using System.Windows;
using Ovotan.Shell.RabbitMQ.Controls.DockPanels;
using Ovotan.Shell.RabbitMQ.Controls.Configurations;
using Ovotan.ApplicationShell.Controls.Models;
using Ovotan.Windows.Controls.Controls;
using Ovotan.Windows.Controls.EndPointManagement.Enums;
using Ovotan.Windows.Controls.EndPointManagement;
using Ovotan.Windows.Controls.EndPointManagements.Interfaces;
using Ovotan.Windows.Controls.Docking.Enums;
using Ovotan.Shell.RabbitMQ.Controls.Services;
using Ovotan.Shell.RabbitMQ.Controls.Enums;
using Ovotan.Windows.Controls.Docking.Interfaces;
using Ovotan.Windows.Controls.EndPointManagement.Configurations;
using Ovotan.Shell.RabbitMQ.Api;
using Ovotan.Windows.Controls.EndPointManagement.Dialogs;
using System.Windows.Controls;

namespace Ovotan.Shell.RabbitMQ.Controls
{
    public class RabbitMQEndPoint : Manager
    {
        ISiteHost _siteHost;
        IDockingMessageQueue _dockingMessageQueue;


        static RabbitMQEndPoint()
        {
            
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RabbitMQEndPoint), new FrameworkPropertyMetadata(typeof(Manager)));
        }

        public RabbitMQEndPoint() : base()
        {

            Header = "RabbitMQ Обозреватель";
            ToolbarActions.Add(new ToolbarButton() { 
                Text = "+", 
                Type = ToolbarElementType.Button,
                Command = new ButtonCommand<object>(_ => _addGroupFolder())
            });
            ToolbarActions.Add(new ToolbarButton()
            {
                Text = "++",
                Type = ToolbarElementType.Button,
                Command = new ButtonCommand<object>(_ => _addCreateConnection())
            });

            MenuViewItems.Add(new MenuItem() { Header = "Тестирование соединений", Command = new ButtonCommand<object>(x => _showTestConnection()) });
        }

        void _showTestConnection()
        {
            var panel = new ConnectionManagement();
            _dockingMessageQueue.Publish(DockingMessageType.ShowDockPanelWindow, panel);
        }

        public override void Start(ISiteHost siteHost, EndPointConfigurations endPointConfigurations, IDockingMessageQueue dockingMessageQueue)
        {
            base.Start(siteHost, endPointConfigurations, dockingMessageQueue);
            treeEventService = new TreeEventService(siteHost, treeView);
            _siteHost = siteHost;
            _dockingMessageQueue = dockingMessageQueue;
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
            treeView.AddDataType(typeof(RabbitMQApiHttpClient));
            var settings = endPointConfigurations.LoadEndPoint<RabbitMQEndPointConfiguration>("RabbitMQ");
            if (settings != null)
            {
                treeView.LoadCoonfigurationNodes(settings.ObjectBrowserTree);
            }
        }

        public async override Task<List<TreeItemModel>> TryExpandNode(TreeItem node)
        {
            var result = new List<TreeItemModel>
            {
                   new TreeItemModel
                   {
                       Type = TreeItemType.Dynamic,
                       Header = "Соедеинения",
                       Tag = TreeItemActionType.Connections
                   },
                   new TreeItemModel
                   {
                        Type = TreeItemType.Dynamic,
                        Header = "Каналы",
                        Tag = TreeItemActionType.Channels
                   },
                   new TreeItemModel
                   {
                        Type = TreeItemType.Dynamic,
                        Header = "Обменники",
                        Tag = TreeItemActionType.Exchanges
                   },
                   new TreeItemModel
                   {
                        Type = TreeItemType.Dynamic,
                        Header = "Очереди",
                        Tag = TreeItemActionType.Queues
                   },
                   new TreeItemModel
                   {
                        Type = TreeItemType.Dynamic,
                        Header = "Стримы",
                        Tag = TreeItemActionType.Streams
                   }
            };
            return result;
        }

        void _addCreateConnection()
        {
            var wnd = new CreateConnectionDialog(typeof(RabbitMQApiHttpClient), "Rabbit");
            wnd.Owner = Application.Current.MainWindow;
            wnd.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            if (wnd.ShowDialog() == true)
            {
                var connection = wnd.Tag as RabbitMQApiHttpClient;
                var selectedNode = treeView.SelectedItem as TreeItem;
                var newNode = new TreeItem() 
                { 
                    Header = connection.ConnectionName, 
                    Tag = connection,
                    Type = TreeItemType.BaseHttpConfiguration,
                    IsChildrenLoaded = false,
                    AllowLazyLoading = true,
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
                var selectedNode = treeView.SelectedItem as TreeItem;
                var newNode = new TreeItem() { Header = folderName, Type = TreeItemType.Configuration };
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

    }
}
