using RabbitMQ.Client;
using System.Collections.ObjectModel;
using System.Windows;

namespace Ovotan.Shell.RabbitMQ.Controls.Dialogs
{
    /// <summary>
    /// Interaction logic for TestConnection.xaml
    /// </summary>
    public partial class TestConnection : Window
    {
        ConnectionFactory _connectionFactory;
        string _hostName;

        public ObservableCollection<IConnection> Connections { get; private set; }

        public TestConnection(string hostName)
        {
            hostName = "localhost";
            _hostName = hostName;
            _connectionFactory = new ConnectionFactory() { HostName = hostName };
            Connections = new ObservableCollection<IConnection>();
        }


        void addNewConnection()
        {
            var connection = _connectionFactory.CreateConnection();
            Connections.Add(connection);
        }
    }
}
