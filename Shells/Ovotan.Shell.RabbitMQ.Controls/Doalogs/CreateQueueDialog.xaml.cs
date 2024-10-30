using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ovotan.Shell.RabbitMQ.Controls.Doalogs
{
    /// <summary>
    /// Interaction logic for CreateQueueWindow.xaml
    /// </summary>
    public partial class CreateQueueDialog : Window
    {
        ConnectionFactory _connectionFactory;
        IConnection _connection;
        IModel _channel;

        public string QueueName { get; set; }
        public bool Durable { get; set; }
        public bool Exclusive { get; set; }
        public bool AutoDelete { get; set; }

        public CreateQueueDialog()
        {
            InitializeComponent();
            _connectionFactory = new ConnectionFactory() { HostName = "localhost" };
            _connection = _connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
            DataContext = this;
        }

        void _addQueue()
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IDictionary<string, object> arguments = null;
            var queue = _channel.QueueDeclare(QueueName, Durable, Exclusive, AutoDelete, arguments);
        }
    }
}
