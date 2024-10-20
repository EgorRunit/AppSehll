using Ovotan.Controls.Docking.Enums;
using Ovotan.Controls.Docking.Interfaces;
using Ovotan.Controls.Docking.Messages;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
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
        List<ElementRectangle> _elementRectangles;
        Point _location;

        public DockPlacementWindow(DockingHost dockingHost, IDockingMessageQueue dockingMessageQueue)
        {
            _dockingHost = dockingHost;
            _dockingMessageQueue = dockingMessageQueue;
            this.MouseUp += DockPlacementWindow_MouseUp;
            this.MouseMove += DockPlacementWindow_MouseMove;
            InitializeComponent();
        }

        FrameworkElement _oldElementUndexMouse = null;
        private void DockPlacementWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseCaptured)
            {
                //var dd = _dockingHost.scr
                Point mousePosition = e.GetPosition(this);
                var x =mousePosition.X + _location.X;
                var y =mousePosition.Y + _location.Y;
                var el = _elementRectangles.FindElementFromPoint(new Point(x,y));
                if (el != null && el.Owner != _oldElementUndexMouse)
                {
                    MainGrid.Visibility = Visibility.Visible;
                    Point relativeLocation = el.Owner.TranslatePoint(new Point(0, 0), this);
                    var top = (el.Owner.ActualHeight - CentralArrow.ActualHeight) / 2 + relativeLocation.Y;
                    var left = (el.Owner.ActualWidth  - CentralArrow.ActualWidth) / 2 + relativeLocation.X;

                    CentralArrow.SetValue(Canvas.TopProperty, top);
                    CentralArrow.SetValue(Canvas.LeftProperty, left);
                    _oldElementUndexMouse = el.Owner;
                    //Debug.WriteLine(relativeLocation);
                    //Debug.WriteLine("Panel enter " + _oldElementUndexMouse.Name);

                }
                else if(_oldElementUndexMouse != null && (el == null || el.Owner != _oldElementUndexMouse))
                {
                    Debug.WriteLine("Panel exit" + _oldElementUndexMouse.Name);
                    _oldElementUndexMouse = null;
                    MainGrid.Visibility = Visibility.Hidden;
                }
                if (el != null)
                {
                    //Debug.WriteLine(el.Owner.ActualHeight + " - " + CentralArrow.ActualHeight);
                }


                _mouseMoveCallback(e);
            }
        }

        private void DockPlacementWindow_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _isMouseCaptured = false;
            _oldElementUndexMouse = null;
            MainGrid.Visibility = Visibility.Hidden;
            ReleaseMouseCapture();
            Hide();
        }

        private void _attachPanel(object sender, MouseButtonEventArgs e)
        {
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
            var panelAttachedMessage = new PanelSplittedMessage() { DockPanelContent = _dragginWindpow.DockPanelContent, PanelSplitted = _oldElementUndexMouse as DockPanel, SplitType = splitType };
            _dragginWindpow.Content = null;
            _dragginWindpow.Close();
            _dockingMessageQueue.Publish(DockingMessageType.PanelSplitted, panelAttachedMessage);
        }


        public void Show(DockPanelWindow dragginWindpow, Action<MouseEventArgs> mouseMoveCallback)
        {
            var startPoints = _dockingHost.PointToScreen(new Point());
            var ss = FindLogicalChildren<IDockPanel>(_dockingHost);
            _elementRectangles = new List<ElementRectangle>(ss.Count());
            _location = _dockingHost.PointToScreen(new Point());
            foreach (var element in ss)
            {
                var frameworkElement = element as FrameworkElement;
                var startPoint = (element as FrameworkElement).PointToScreen(new Point());
                _elementRectangles.Add(new ElementRectangle(frameworkElement, startPoint.X, startPoint.Y, startPoint.X + frameworkElement.ActualWidth,startPoint.Y + frameworkElement.ActualHeight));
            }
            _oldElementUndexMouse = null;
            _dragginWindpow = dragginWindpow;
            _isMouseCaptured = true;
            _mouseMoveCallback = mouseMoveCallback;
            Top = startPoints.Y;
            Left = startPoints.X;
            Height = _dockingHost.ActualHeight;
            Width = _dockingHost.ActualWidth;

            Show();
            MainGrid.Visibility = Visibility.Hidden;
            Mouse.Capture(this, CaptureMode.SubTree);
        }

        public static IEnumerable<T> FindLogicalChildren<T>(DependencyObject obj) where T : class
        {
            if (obj != null)
            {
                if (obj is T)
                    yield return obj as T;

                foreach (DependencyObject child in LogicalTreeHelper.GetChildren(obj).OfType<DependencyObject>())
                    foreach (T c in FindLogicalChildren<T>(child))
                        yield return c;
            }
        }
    }
}
