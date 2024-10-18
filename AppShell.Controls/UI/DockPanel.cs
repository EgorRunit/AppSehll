using AppShell.Controls.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace AppShell.Controls.UI
{
    public class DockPanel : Grid, IDockPanel
    {
        //Экземпляр очереди сообщений элметов докинга
        IDockingManagerMessageQueue _dockMessageQueue;
        Binding _bindingHeaderBackgroundBrush;
        Binding _bindingHeaderActiveBackgroundBrush;


        Grid _header;

        TextBlock _textBlockCaption;
        StackPanel _stackPanel;
        Button _right;
        Button _top;
        Button _left;
        Button _bottom;
        static int index = 0;

        public bool IsActive { get; set; }

        static DockPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DockPanel), new FrameworkPropertyMetadata(typeof(DockPanel)));
        }

        public DockPanel()
        {

        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
        }

        internal DockPanel(IDockingManagerMessageQueue dockMessageQueue)
        {
            _dockMessageQueue = dockMessageQueue;

            Background = new SolidColorBrush(Colors.Transparent);
            this.Focusable = true;
            this.GotMouseCapture += (x, y) => ChangeFocusState(true);
            this.MouseDown += (x, y) => ChangeFocusState(true);

            RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0.0, GridUnitType.Auto) });
            RowDefinitions.Add(new RowDefinition() { Height = new GridLength(100.0, GridUnitType.Star) });
            RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0.0, GridUnitType.Auto) });
            ColumnDefinitions.Add(new ColumnDefinition());

            index++;

            var dockingManagerSetting = FindResource("DockingManagerSetting") as DockingManagerSetting;
            _bindingHeaderBackgroundBrush = new Binding("DockGridContentHeader_Background");
            _bindingHeaderActiveBackgroundBrush = new Binding("DockGridContentHeader_ActiveBackground");
            _bindingHeaderBackgroundBrush.Source = dockingManagerSetting;
            _bindingHeaderActiveBackgroundBrush.Source = dockingManagerSetting;
            var bindigHeaderForeground = new Binding("DockGridContentHeader_Foreground");
            bindigHeaderForeground.Source = dockingManagerSetting;


            _header = new Grid();
            _header.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100.0, GridUnitType.Star) });
            _header.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0, GridUnitType.Auto) });
            _header.SetBinding(Grid.BackgroundProperty, _bindingHeaderBackgroundBrush);
            //_header.RowDefinitions.Add(new RowDefinition());
            //_header.ColumnDefinitions.Add(new ColumnDefinition());

            _textBlockCaption = new TextBlock() { Text = "Window " + index };
            _textBlockCaption.SetBinding(TextBlock.ForegroundProperty, bindigHeaderForeground);
            _textBlockCaption.Padding = new Thickness(5, 2, 0, 3);
            _textBlockCaption.TextTrimming = TextTrimming.CharacterEllipsis;

            var closeButtonIcon = FindResource("ButtonIconClose") as Geometry;
            var closeButton = new IconButton();
            closeButton.Click += (x, y) => _panelClosed();
            closeButton.Icon = closeButtonIcon;
            closeButton.HorizontalAlignment = HorizontalAlignment.Right;
            closeButton.Foreground = new SolidColorBrush(Colors.Black);
            //closeButton.MouseMove += CloseButton_MouseMove;
            closeButton.Margin = new Thickness(0, 0, 5, 0);
            closeButton.SetValue(Grid.ColumnProperty, 1);

            var pinButtonIcon = FindResource("ButtonIconPin") as Geometry;
            var pinButton = new IconButton();
            //pinButton.Click += CloseButton_Click;
            pinButton.Icon = pinButtonIcon; ;
            pinButton.HorizontalAlignment = HorizontalAlignment.Right;
            pinButton.Foreground = new SolidColorBrush(Colors.Black);
            //pinButton.MouseMove += CloseButton_MouseMove;
            pinButton.Margin = new Thickness(0, 0, 23, 0);
            pinButton.SetValue(Grid.ColumnProperty, 1);

            _header.Children.Add(_textBlockCaption);
            _header.Children.Add(pinButton);
            _header.Children.Add(closeButton);




            _stackPanel = new StackPanel();
            _stackPanel.SetValue(Grid.RowProperty, 1);

            _right = new Button() { Content = "right", CommandParameter = DockPanelAttachedType.Right };
            _right.Click += _buttonHandlers;

            _left = new Button() { Content = "left", CommandParameter = DockPanelAttachedType.Left };
            _left.Click += _buttonHandlers;

            _top = new Button() { Content = "top", CommandParameter = DockPanelAttachedType.Top };
            _top.Click += _buttonHandlers;

            _bottom = new Button() { Content = "bottom", CommandParameter = DockPanelAttachedType.Bottom };
            _bottom.Click += _buttonHandlers;

            _stackPanel.Children.Add(_left);
            _stackPanel.Children.Add(_right);
            _stackPanel.Children.Add(_top);
            _stackPanel.Children.Add(_bottom);

            Children.Add(_header);
            Children.Add(_stackPanel);
            if (index > 1)
            {
                Background = new SolidColorBrush(Colors.Aqua);
            }

        }

        /// <summary>
        /// Обработчик события получения содержисого панели фокуса.
        /// </summary>
        /// <param name="focusable">True - Содержисое панели стало активным, false в противном случае.</param>
        public void ChangeFocusState(bool focusable)
        {
            if (focusable && !IsActive)
            {
                IsActive = true;
                _header.SetBinding(StackPanel.BackgroundProperty, _bindingHeaderActiveBackgroundBrush);
                _dockMessageQueue.Publish(DockingManagerMessageType.PanelGotFocus, this);
            }
            if (!focusable && IsActive)
            {
                _header.SetBinding(StackPanel.BackgroundProperty, _bindingHeaderBackgroundBrush);
                IsActive = false;
            }
        }

        void _panelClosed()
        {
            _dockMessageQueue.Publish(DockingManagerMessageType.PanelClosed, this);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _buttonHandlers(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var args = new PanelSPlittedMessgage() { PanelSplitted = this, SplitType = (DockPanelAttachedType)button.CommandParameter };
            _dockMessageQueue.Publish(DockingManagerMessageType.PanelSplitted, args);
        }
    }
}



//dockingManagerSetting.SetValue(DockingManagerSetting.DockGridContentHeader_Background_Property, new SolidColorBrush(Colors.Red));
// dockingManagerSetting.SetValue(DockingManagerSetting.DockGridContentHeader_Foreground_Property, new SolidColorBrush(Colors.Black));
//_textBlockCaption.Background

