using Ovotan.Controls.Docking.Enums;
using Ovotan.Controls.Docking.Interfaces;
using Ovotan.Controls.Docking.Messages;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Ovotan.Controls.Docking.Windows
{
    /// <summary>
    /// Interaction logic for DockPlacementWindow.xaml
    /// </summary>
    public partial class DockPlacementWindow : Window
    {
        bool _isMouseCaptured;
        DockPanelWindow _dragginWindpow;
        IDockingMessageQueue _dockingMessageQueue;
        DockingHost _dockingHost;
        Action<MouseEventArgs> _mouseMoveCallback;

        public DockPlacementWindow(DockingHost dockingHost, IDockingMessageQueue dockingMessageQueue)
        {
            _dockingHost = dockingHost;
            _dockingMessageQueue = dockingMessageQueue;
            this.MouseUp += DockPlacementWindow_MouseUp;
            this.MouseMove += DockPlacementWindow_MouseMove;
            InitializeComponent();
        }

        private void DockPlacementWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseCaptured)
            {
                Debug.WriteLine(Mouse.DirectlyOver + " " + Mouse.Captured);
                _mouseMoveCallback(e);
            }
        }

        private void DockPlacementWindow_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _isMouseCaptured = false;
            ReleaseMouseCapture();
            Hide();
        }

        private void _attachPanel(object sender, MouseButtonEventArgs e)
        {
            _isMouseCaptured = false;
            ReleaseMouseCapture();
            Hide();
            var args = sender as CanvasButton;
            PanelAttachedType attachType = PanelAttachedType.Left;
            switch (args.CanvasButtonType)
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
            var panelAttachedMessage = new PanelAttachedMessage() { Type = attachType, DockPanelContent = _dragginWindpow.DockPanelContent};
            _dragginWindpow.Content = null;
            _dragginWindpow.Close();
            _dockingMessageQueue.Publish(DockingMessageType.PanelAttached, panelAttachedMessage);
        }

        private void _splitPanel(object sender, MouseButtonEventArgs e)
        {
            _isMouseCaptured = false;
            ReleaseMouseCapture();
            Hide();
            var args = sender as CanvasButton;
            PanelSplittedType splitType = PanelSplittedType.Left;
            switch (args.CanvasButtonType)
            {
                case CanvasButtonType.WindowRightDock:
                    splitType = PanelSplittedType.Right;
                    break;
                case CanvasButtonType.WindowTopDock:
                    splitType = PanelSplittedType.Top;
                    break;
                case CanvasButtonType.WindowBottomDock:
                    splitType = PanelSplittedType.Bottom;
                    break;
            }
            var panelAttachedMessage = new PanelSplittedMessage() { PanelSplitted = null, SplitType = splitType };
            _dragginWindpow.Content = null;
            _dragginWindpow.Close();
            _dockingMessageQueue.Publish(DockingMessageType.PanelSplitted, panelAttachedMessage);
        }


        public void Show(DockPanelWindow dragginWindpow, Action<MouseEventArgs> mouseMoveCallback)
        {            
            _dragginWindpow = dragginWindpow;
            _isMouseCaptured = true;
            _mouseMoveCallback = mouseMoveCallback;
            var startPoints = _dockingHost.PointToScreen(new Point());
            Top = startPoints.Y;
            Left = startPoints.X;
            Height = _dockingHost.ActualHeight;
            Width = _dockingHost.ActualWidth;
            Show();
            Mouse.Capture(this, CaptureMode.SubTree);
        }
    }
}
