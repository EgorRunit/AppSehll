using Ovotan.Shell.RabbitMQ.Api;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ovotan.Shell.RabbitMQ.Controls.DockPanels
{
    public class ConnectionManagement : ContentControl
    {
        ConnectionFactory _connectionFactory;
        ObservableCollection<IConnection> _connections;

        static ConnectionManagement()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DockPanel), new FrameworkPropertyMetadata(typeof(DockPanel)));
        }

        public ConnectionManagement()
        {
            _connectionFactory = new ConnectionFactory() { HostName = "localhost" };
            _connections = new ObservableCollection<IConnection>();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var addButton = Template.FindName("AddButton", this) as Button;
            var deleteButton = Template.FindName("DeleteButton", this) as Button;
            var connectionList = Template.FindName("ConnectionList", this) as DataGrid;
            addButton.Click += _addButton_Click;

            connectionList.ItemsSource = _connections;

        }

        void _addButton_Click(object sender, RoutedEventArgs e)
        {
            var connection = _connectionFactory.CreateConnection("werwerwerew");
            _connections.Add(connection);

            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                var ss = RabbitMQApiHttpClient.Connect("guest", "guest", "http://localhost:15672/").ConfigureAwait(false);
                var ssss = ss.GetAwaiter().GetResult();
                var result = ssss.ConnectionApi.GetConnections().ConfigureAwait(false);
                Mouse.OverrideCursor = null;
            }
            catch (Exception ex)
            {
            }
        }
    }
}
