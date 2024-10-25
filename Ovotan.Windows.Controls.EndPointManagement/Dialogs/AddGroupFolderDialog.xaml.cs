using System.Windows;

namespace Ovotan.Windows.Controls.EndPointManagement.Dialogs
{
    /// <summary>
    /// Interaction logic for AddGroupFolderDialog.xaml
    /// </summary>
    public partial class AddGroupFolderDialog : Window
    {
        public AddGroupFolderDialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
