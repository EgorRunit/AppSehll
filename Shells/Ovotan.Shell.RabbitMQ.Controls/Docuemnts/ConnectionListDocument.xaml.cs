using Ovotan.Shell.RabbitMQ.Api;
using Ovotan.Shell.RabbitMQ.Controls.Services;
using Ovotan.Windows.Controls.Docking.Interfaces;
using System.ComponentModel;
using System.Windows.Controls;

namespace Ovotan.Shell.RabbitMQ.Controls.Docuemnts
{

    /// <summary>
    /// SiteHost документ.
    /// Список активныз подключений.
    /// </summary>
    public partial class ConnectionListDocument : UserControl, ISiteHostDocument
    {
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


        private void DataGridConnections_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyDescriptor is PropertyDescriptor descriptor)
            {
                e.Column.Header = descriptor.DisplayName ?? descriptor.Name;
            }

        }
    }




    
}
