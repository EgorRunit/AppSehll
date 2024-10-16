using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace AppShell.Controls.UI
{
    public class DockPanelCellContent : Grid
    {
        //Экземпляр очереди сообщений элметов докинга
        IDockingManagerMessageQueue _dockMessageQueue;


                Grid _header;

        TextBlock _textBlockCaption;
        StackPanel _stackPanel;
        Button _right;
        Button _top;
        Button _left;
        Button _bottom;
        static int index = 0;
        
        public bool IsActive { get; set; }

        static DockPanelCellContent()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DockPanelCellContent), new FrameworkPropertyMetadata(typeof(DockPanelCellContent)));
        }

        public DockPanelCellContent()
        {

        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
        }

        internal DockPanelCellContent(IDockingManagerMessageQueue dockMessageQueue)
        {
            _dockMessageQueue = dockMessageQueue;

            Background = new SolidColorBrush(Colors.Transparent);
            this.Focusable = true;
            this.MouseDown += _gotFocus;   

            RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0.0, GridUnitType.Auto) });
            RowDefinitions.Add(new RowDefinition() { Height = new GridLength(100.0, GridUnitType.Star) });
            RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0.0, GridUnitType.Auto) });
            ColumnDefinitions.Add(new ColumnDefinition());

            index++;

            var dockingManagerSetting = FindResource("DockingManagerSetting") as DockingManagerSetting;
            var bindigHeaderBackground = new Binding("DockGridContentHeader_Background");
            bindigHeaderBackground.Source = dockingManagerSetting;
            var bindigHeaderForeground = new Binding("DockGridContentHeader_Foreground");
            bindigHeaderForeground.Source = dockingManagerSetting;


            _header = new Grid();
            _header.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100.0, GridUnitType.Star) });
            _header.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0, GridUnitType.Auto) });
            _header.SetBinding(Grid.BackgroundProperty, bindigHeaderBackground);
            //_header.RowDefinitions.Add(new RowDefinition());
            //_header.ColumnDefinitions.Add(new ColumnDefinition());

            _textBlockCaption = new TextBlock() { Text = "Window " + index };
            _textBlockCaption.SetBinding(TextBlock.ForegroundProperty, bindigHeaderForeground);
            _textBlockCaption.Padding = new Thickness(5,2,0,3);
            _textBlockCaption.TextTrimming = TextTrimming.CharacterEllipsis;
            
            var closeButtonIcon = FindResource("ButtonIconClose") as Geometry;
            var closeButton = new IconButton();
            //closeButton.Click += CloseButton_Click;
            closeButton.Icon = closeButtonIcon; 
            closeButton.HorizontalAlignment = HorizontalAlignment.Right;
            closeButton.Foreground = new SolidColorBrush(Colors.Black);
            //closeButton.MouseMove += CloseButton_MouseMove;
            closeButton.Margin = new Thickness(0, 0,5, 0);
            closeButton.SetValue(Grid.ColumnProperty, 1);

            var pinButtonIcon = FindResource("ButtonIconPin") as Geometry;
            var pinButton = new IconButton();
            //pinButton.Click += CloseButton_Click;
            pinButton.Icon = pinButtonIcon;;
            pinButton.HorizontalAlignment = HorizontalAlignment.Right;
            pinButton.Foreground = new SolidColorBrush(Colors.Black);
            //pinButton.MouseMove += CloseButton_MouseMove;
            pinButton.Margin = new Thickness(0,0,23,0);
            pinButton.SetValue(Grid.ColumnProperty, 1);

            _header.Children.Add(_textBlockCaption);
            _header.Children.Add(pinButton);
            _header.Children.Add(closeButton);




            _stackPanel = new StackPanel();
            _stackPanel.SetValue(Grid.RowProperty, 1);

            _right = new Button() { Content = "right", CommandParameter = DockPanelAttachedType.Right };
            _right.Click += _right_Click;

            _left = new Button() { Content = "left", CommandParameter = DockPanelAttachedType.Left };
            _left.Click += _right_Click;

            _top = new Button() { Content = "top", CommandParameter = DockPanelAttachedType.Top };
            _top.Click += _right_Click;

            _bottom = new Button() { Content = "bottom", CommandParameter = DockPanelAttachedType.Bottom };
            _bottom.Click += _right_Click;

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


        void _gotFocus(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!IsActive)
            {

            }
        }


        private void _right_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var args = new DockingManagerPanelAttachedArgs() { DockPanelCellContent = this, DockPanelAttachedType = (DockPanelAttachedType)button.CommandParameter };
            _dockMessageQueue.Publish(DockingManagerMessageType.PanelAttached, args);
            //dockingManagerSetting.SetValue(DockingManagerSetting.DockGridContentHeader_Background_Property, new SolidColorBrush(Colors.Red));
           // dockingManagerSetting.SetValue(DockingManagerSetting.DockGridContentHeader_Foreground_Property, new SolidColorBrush(Colors.Black));
            //_textBlockCaption.Background
        }
    }
}
