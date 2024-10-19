using Ovotan.Controls.Docking.Enums;
using Ovotan.Controls.Docking.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Ovotan.Controls.Docking.Windows
{
    /// <summary>
    /// Interaction logic for DockPanelWindow.xaml
    /// </summary>
    public partial class DockPanelWindow : Window, IDockPanelWindow
    {
        DockPlacementWindow _dockPlacementWindow;
        IDockingMessageQueue _dockingMessageQueue;
        Point _location;
        DockingHost _docking;


        public DockPanelWindow()
        {
            InitializeComponent();
        }

        public void Initialize(DockPlacementWindow dockPlacementWindow, IDockingMessageQueue dockingMessageQueue)
        {
            _dockPlacementWindow = dockPlacementWindow;
            _dockingMessageQueue = dockingMessageQueue;
        }

        private void DockPanelWindow_MouseMove(MouseEventArgs e)
        {
            Point mousePosition = e.GetPosition(this);
            this.Left = this.Left + (mousePosition.X - _location.X);
            this.Top = this.Top + (mousePosition.Y - _location.Y);
        }

        void _grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _location = e.GetPosition(this);
            _dockPlacementWindow.Show(this, DockPanelWindow_MouseMove);
        }

    }
}
