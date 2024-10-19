using Ovotan.Controls.Docking.Enums;
using Ovotan.Controls.Docking.Windows;
using System;
using System.Windows;
using System.Windows.Input;

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


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new DockPanelWindow();
            MainDockingManager._showDockPanelWindow(wnd);
        }
    }
}
