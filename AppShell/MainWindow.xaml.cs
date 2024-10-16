using AppShell.Controls;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppShell
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //ISnapManagerMessageQueue _messageQueue;

        public MainWindow()
        {
            InitializeComponent();
            //_messageQueue = new SnapManagerMessageQueue();
            //Content = new SnapManager(_messageQueue) { Tag = "EEEEEEEEEEEE" };
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
        }
    }
}
