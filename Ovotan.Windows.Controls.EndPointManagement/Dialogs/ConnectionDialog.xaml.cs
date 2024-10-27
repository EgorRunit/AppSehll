using Ovotan.EndPointManagement.Connections;
using System.Windows;

namespace Ovotan.Windows.Controls.EndPointManagement.Dialogs
{
    /// <summary>
    /// Диалог проверки подключения к конечной точке с помощью HttpClientBase.
    /// </summary>
    public partial class ConnectionDialog : Window
    {
        internal ConnectionDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="httpClientBase">Экземпляр клиента HttpClientBase.</param>
        public ConnectionDialog(HttpClientBase httpClientBase)
        {
            InitializeComponent();
            Title = $"Установка соединения {httpClientBase.ConnectionName}";
            ToolTip = Title;

            var task = httpClientBase.TryConnectionAsync(httpClientBase.BaseUrl, httpClientBase.UserName, httpClientBase.UserPassword);
            task.ContinueWith((x) =>
            {
                if (task.Result.success)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        DialogResult = true;
                        Close();
                    }));
                }
                else
                {
                    MessageBox.Show(task.Result.reasonPhrase, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }
    }
}
