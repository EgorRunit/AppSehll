using AppShell.Controls;
using AppShell.Controls.UI;
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

        private void CanvasButton_MouseDown(object sender, MouseButtonEventArgs e)
        {

            var window = new Window() { Topmost = true };
            var s1 = this.Left;
            var s2 = this.Padding;
            var s3 = Margin;
            var dd = this.PointToScreen(new Point());

            window.Top = Application.Current.MainWindow.Top; 
            window.Left = Application.Current.MainWindow.Left;
            window.Height = ActualHeight;
            window.Width = ActualWidth;
            window.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var windowType = CanvasButtonType.WindowLeftDock;
            DockPanelAttachedType attachedType = DockPanelAttachedType.Top;
            switch(windowType)
            {
                case CanvasButtonType.WindowLeftDock:
                    attachedType = DockPanelAttachedType.Left; 
                    break;
                case CanvasButtonType.WindowRightDock:
                    attachedType = DockPanelAttachedType.Right;
                    break;
                case CanvasButtonType.WindowBottomDock:
                    attachedType = DockPanelAttachedType.Bottom;
                    break;
            }
            MainDockingManager.AttachedPanel(attachedType);
        }
    }
}
