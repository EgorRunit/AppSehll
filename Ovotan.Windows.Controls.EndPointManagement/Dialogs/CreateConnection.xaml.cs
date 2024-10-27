using Ovotan.EndPointManagement.Connections;
using System.Windows;

namespace Ovotan.Windows.Controls.EndPointManagement.Dialogs
{
    /// <summary>
    /// Системный диалог подключения к конечной точке по Http.
    /// </summary>
    public partial class CreateConnectionDialog : Window
    {
        public string ConnectionName { get;set; }
        public int Port { get; set; }
        public string Host { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public Type _type;

        public CreateConnectionDialog()
        {
            InitializeComponent();
        }

        public CreateConnectionDialog(Type type, string endPointName)
        {
            InitializeComponent();
            _type = type;
            Title = $"Новое подключение к {endPointName}";
            ConnectionName = "";
            Login = "guest";
            Password = "guest";
            Port = 15672;
            Host = "localhost";
            DataContext = this;
        }

        async void Button_Click(object sender, RoutedEventArgs e)
        {
            var client = Activator.CreateInstance(_type) as HttpClientBase;
            var host = Host.Trim();
            if(host.IndexOf("//") == -1)
            {
                host = $"http://{host}";
            }
            host = $"{host}:{Port}";

            var result = await client.TryConnectionAsync(host, Login.Trim(), Password.Trim());
            if (result.success)
            {
                ConnectionName = ConnectionName.Trim();
                if(ConnectionName == string.Empty)
                {
                    ConnectionName = host;
                }
                client.ConnectionName = ConnectionName.Trim();
                Tag = client;
                DialogResult = true;
            }
        }
    }
}
