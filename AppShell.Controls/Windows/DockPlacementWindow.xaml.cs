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
using System.Windows.Shapes;

namespace AppShell.Controls.Windows
{
    /// <summary>
    /// Interaction logic for DockPlacementWindow.xaml
    /// </summary>
    public partial class DockPlacementWindow : Window
    {
        public DockPlacementWindow()
        {
            
            InitializeComponent();
        }

        private void CanvasButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var button = sender as CanvasButton;
        }
    }
}
