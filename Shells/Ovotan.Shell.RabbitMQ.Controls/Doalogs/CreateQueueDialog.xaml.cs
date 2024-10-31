using Ovotan.Shell.RabbitMQ.Api;
using Ovotan.Windows.Controls.EndPointManagement.Dialogs;
using System.Windows;

namespace Ovotan.Shell.RabbitMQ.Controls.Doalogs
{
    /// <summary>
    /// Dialogue for creating a new queue
    /// </summary>
    public partial class CreateQueueDialog : Window
    {
        RabbitMQApiHttpClient _client;
        public string QueueName { get; set; }
        public bool Durable { get; set; }
        public bool Exclusive { get; set; }
        public bool AutoDelete { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public CreateQueueDialog(RabbitMQApiHttpClient client)
        {

            InitializeComponent();
            DataContext = this;
            _client = client;
        }

        /// <summary>
        /// Queue creation handler.
        /// </summary>
        void _addQueue(object sender, RoutedEventArgs e)
        {
            IDictionary<string, object> arguments = null;
            try
            {
                var channel = _client.GetChannel();
                var queue = channel.QueueDeclare(QueueName, Durable, Exclusive, AutoDelete, arguments);
                Close();
            }
            catch (Exception ex)
            {
                var wnd = new ErrorDialog(ex.Message);
                wnd.ShowDialog();
            }
        }
    }
}
