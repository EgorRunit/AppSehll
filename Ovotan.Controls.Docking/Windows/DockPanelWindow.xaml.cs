using Ovotan.Controls.Docking.Interfaces;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ovotan.Controls.Docking.Windows
{
    /// <summary>
    /// Окно ператскавания DockPanelCntent
    /// </summary>
    public partial class DockPanelWindow : Window, IDockPanelWindow
    {
        DockPlacementWindow _dockPlacementWindow;
        IDockingMessageQueue _dockingMessageQueue;
        Point _location;

        public FrameworkElement DockPanelContent { get; private set; }

        public DockPanelWindow(DockPlacementWindow dockPlacementWindow, FrameworkElement contentElement)
        {
            _dockPlacementWindow = dockPlacementWindow;
            InitializeComponent();
            DockPanelContent = contentElement;
            DockPanelContent.SetValue(Grid.RowProperty, 1);
            DockPanelContent.SetValue(HorizontalAlignmentProperty, HorizontalAlignment.Stretch);
            DockPanelContent.SetValue(VerticalAlignmentProperty, VerticalAlignment.Stretch);
            DockPanelContent.SetValue(Grid.RowProperty, 1);
            MainGrid.Children.Add(DockPanelContent);
        }

        public void Initialize(IDockingMessageQueue dockingMessageQueue)
        {
            _dockingMessageQueue = dockingMessageQueue;
        }

        void DockPanelWindow_MouseMove(MouseEventArgs e)
        {
            Point mousePosition = e.GetPosition(this);
            Left =Left + (mousePosition.X - _location.X);
            Top = Top + (mousePosition.Y - _location.Y);
        }

        void _grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _location = e.GetPosition(this);
            _dockPlacementWindow.Show(this, DockPanelWindow_MouseMove);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            MainGrid.Children.Clear();
        }
    }
}
