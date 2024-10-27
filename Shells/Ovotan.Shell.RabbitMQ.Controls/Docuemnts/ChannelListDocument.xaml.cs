using Ovotan.Shell.RabbitMQ.Api;
using Ovotan.Shell.RabbitMQ.Controls.Services;
using Ovotan.Windows.Controls.Docking.Interfaces;
using System.Windows.Controls;

namespace Ovotan.Shell.RabbitMQ.Controls.Docuemnts
{
    /// <summary>
    /// Interaction logic for ChannelListDocument.xaml
    /// </summary>
    public partial class ChannelListDocument : UserControl, ISiteHostDocument
    {
        RabbitMQApiHttpClient _cleint;

        public bool IsStatic { get; } = true;

        public Guid ID { get; } = RabbitMQDocumentTDs.Channels;

        public string Header { get; private set; }

        public ChannelListDocument(RabbitMQApiHttpClient client)
        {
            InitializeComponent();
            Header = "Список активных каналов";
            _cleint = client;
        }
    }
}
