using Ovotan.Controls.Docking.Enums;
using Ovotan.Controls.Docking.Interfaces;
using System.Windows;
using System.Windows.Input;

namespace Ovotan.Controls.Docking.Windows
{
    /// <summary>
    /// Interaction logic for DockPlacementWindow.xaml
    /// </summary>
    public partial class DockPlacementWindow : Window
    {
        IDockingMessageQueue _dockingMessageQueue;

        public DockPlacementWindow(IDockingMessageQueue dockingMessageQueue)
        {
            _dockingMessageQueue = dockingMessageQueue;
            InitializeComponent();
        }

        private void CanvasButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var args = sender as CanvasButton;
            PanelAttachedType attachType = PanelAttachedType.Left;
            switch(args.CanvasButtonType)
            {
                case CanvasButtonType.WindowRightDock:
                    attachType = PanelAttachedType.Right;
                    break;
                case CanvasButtonType.WindowTopDock:
                    attachType = PanelAttachedType.Top;
                    break;
                case CanvasButtonType.WindowBottomDock:
                    attachType = PanelAttachedType.Bottom;
                    break;
            }
            _dockingMessageQueue.Publish(DockingMessageType.PanelAttached, attachType);
        }
    }
}
