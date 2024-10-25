using Ovotan.Shell.RabbitMQ.Api;
using Ovotan.Shell.RabbitMQ.Controls.Models;
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
    /// Interaction logic for CreateConnection.xaml
    /// </summary>
    public partial class CreateConnectionDialog
        : Window
    {
        public string Name { get;set; }
        public int Port { get; set; }
        public string Host { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public CreateConnectionDialog()
        {
            InitializeComponent();
            Name = "";
            Login = "guest";
            Password = "guest";
            Port = 15672;
            Host = "localhost";
            DataContext = this;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            var host = $"http://{Host.Trim()}:{Port}";
            var client = Task.Run(async () => await RabbitMQApiHttpClient.Connect(Login.Trim(), Password.Trim(), host));
            client.Wait();
            if (client.Result != null)
            {
                if(Name.Trim() == string.Empty)
                {
                    Name = host;
                }
                var model = new EndPointConnection()
                {
                    Name = host,
                    Host = host,
                    Port = Port,
                    Password = Password.Trim(),
                    Login = Login.Trim(),
                };
                var httpClient = client.Result;
                Tag = model;
                DialogResult = true;
            }
            
        }
    }
}
