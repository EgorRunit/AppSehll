using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ovotan.Shell.RabbitMQ.Controls.DockPanels
{
    /// <summary>
    /// Interaction logic for QueueManagement.xaml
    /// </summary>
    public partial class QueueManagement : UserControl
    {
        ConnectionFactory _connectionFactory;
        IConnection _connection;
        IModel _channel;

        public ObservableCollection<QueueDeclareOk> Queues { get; set; } 

        public QueueManagement()
        {
            InitializeComponent();
            Queues = new ObservableCollection<QueueDeclareOk>();
            _connectionFactory = new ConnectionFactory() { HostName = "localhost" };
            _connection = _connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
            DataGridQueues.ItemsSource = Queues;
        }

        void _addQueue()
        {
            var queueName = "eee";
            var durable = false;
            var exclusive = true;
            var autoDelete = true;
            IDictionary<string, object> arguments = null;
            var queue = _channel.QueueDeclare(queueName, durable, exclusive, autoDelete, arguments);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
