using Ovotan.Shell.RabbitMQ.Api;
using Ovotan.Shell.RabbitMQ.Controls.Services;
using Ovotan.Windows.Controls.Docking.Interfaces;
using System.Windows.Controls;

namespace Ovotan.Shell.RabbitMQ.Controls.Docuemnts
{

    /// <summary>
    /// SiteHost документ.
    /// Список активныз подключений.
    /// </summary>
    public partial class ConnectionListDocument : UserControl, ISiteHostDocument
    {
        /// <summary>
        /// Экземпляр Http клиента для даступа к апи.
        /// </summary>
        RabbitMQApiHttpClient _client;
        public bool IsStatic { get; } = true;
        public Guid ID { get; } = RabbitMQDocumentTDs.Connections;
        public string Header { get; private set; }

        public ConnectionListDocument(RabbitMQApiHttpClient client)
        {
            InitializeComponent();
            Header = "Rabbit - Список активных подключений";
            _client = client;
            Refresh();
    
        }
        public void Refresh()
        {
            var task = _client.ConnectionApi.GetConnectionsAsync();
            task.ContinueWith((x) =>
            {
                Dispatcher.Invoke(new Action(() =>
                {
                    DataGridConnections.ItemsSource = x.Result;
                }));
            });

        }

        void _refresh(object sender, System.Windows.RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
