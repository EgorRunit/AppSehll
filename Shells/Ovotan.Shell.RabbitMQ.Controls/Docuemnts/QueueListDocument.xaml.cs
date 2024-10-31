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
    /// 
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
            Header = "Rabbit - Список Очередей";
            InitializeComponent();
            _client = client;
            DataContext = this;
            SiteHostDocumentDataGrid.Header = Header;
            SiteHostDocumentDataGrid.DataBindCommand = new ButtonCommand<object>(x => _getQueues());
            CreateQueueCommand = new ButtonCommand<object>(_ => _addQueue());

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

        void _addQueue()
        {
            var wnd = new CreateQueueDialog(_client);
            wnd.Owner = Application.Current.MainWindow;
            wnd.ShowDialog();
            _getQueues();
        }
    }
}
