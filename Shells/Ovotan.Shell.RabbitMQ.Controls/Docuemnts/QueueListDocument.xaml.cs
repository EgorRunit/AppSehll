using Ovotan.Shell.RabbitMQ.Api;
using Ovotan.Shell.RabbitMQ.Controls.Doalogs;
using Ovotan.Shell.RabbitMQ.Controls.Services;
using Ovotan.Windows.Controls.Controls;
using Ovotan.Windows.Controls.Docking.Interfaces;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Ovotan.Shell.RabbitMQ.Controls.Docuemnts
{
    /// <summary>
    /// Interaction logic for QueueListDocument.xaml
    /// </summary>
    public partial class QueueListDocument : UserControl, ISiteHostDocument
    {
        /// <summary>
        /// Экземпляр Http клиента для даступа к апи.
        /// </summary>
        RabbitMQApiHttpClient _client;
        public bool IsStatic { get; } = true;
        public Guid ID { get; } = RabbitMQDocumentTDs.Queues;
        public string Header { get; private set; }

        public ICommand CreateQueueCommand { get; set; }

        public QueueListDocument(RabbitMQApiHttpClient client)
        {
            InitializeComponent();
            Header = "Rabbit - Список Очередей";
            _client = client;
            DataContext = this;
            SiteHostDocumentDataGrid.DataBindCommand = new ButtonCommand<object>(x => _getQueues());
            CreateQueueCommand = new ButtonCommand<object>(_ =>
            {
                var de = 4;
            });

        }
        void _getQueues()
        {
            var task = _client.QueueApi.GetQueuesAsync();
            task.ContinueWith((x) =>
            {
                Dispatcher.Invoke(new Action(() =>
                {
                    SiteHostDocumentDataGrid.DataBind(task.Result);
                }));
            });

        }

        void _addQueue(object sender, RoutedEventArgs e)
        {
            var wnd = new CreateQueueDialog();
            wnd.Owner = Application.Current.MainWindow;
            wnd.Topmost = true;
            wnd.Show();
        }
    }
}
