using System.Windows;

namespace Ovotan.Windows.Controls.EndPointManagement.Dialogs
{
    /// <summary>
    /// Диалог создания новой групповой папки.
    /// </summary>
    public partial class AddGroupFolderDialog : Window
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public AddGroupFolderDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик добавления новой групповой папки.
        /// </summary>
        void _addFolder(object sender, RoutedEventArgs e)
        {
            var name = GroupFolderName.Text.Trim();
            if (name == string.Empty)
            {
                MessageBox.Show("Указно некорректное название папки","Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DialogResult = true;
                Content = name;
                Close();
            }
        }
    }
}
