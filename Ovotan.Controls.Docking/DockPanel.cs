using Ovotan.Controls.Docking.Enums;
using Ovotan.Controls.Docking.Interfaces;
using Ovotan.Controls.Docking.Messages;
using Ovotan.Controls.Docking.Settings;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Ovotan.Controls.Docking
{
    public class DockPanel : Grid, IDockPanel
    {
        //Экземпляр очереди сообщений элметов докинга
        IDockingMessageQueue _dockMessageQueue;

        Binding _bindingHeaderBackgroundBrush;
        Binding _bindingHeaderActiveBackgroundBrush;
        Binding _bindigHeaderForeground;
        Binding _bindigHeaderActiveForeground;


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

        internal DockPanel(IDockingMessageQueue dockMessageQueue, FrameworkElement dockPanelContent)
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

            var canvasButtonSettings = FindResource("Ovotan_Control_DockPanel_Settings") as PanelSettings;
            _bindingHeaderBackgroundBrush = new Binding("HeaderBackground");
            _bindingHeaderBackgroundBrush.Source = canvasButtonSettings;
            _bindingHeaderActiveBackgroundBrush = new Binding("HeaderActiveBackground");
            _bindingHeaderActiveBackgroundBrush.Source = canvasButtonSettings;
            _bindigHeaderForeground = new Binding("HeaderForeground");
            _bindigHeaderForeground.Source = canvasButtonSettings;
            _bindigHeaderActiveForeground = new Binding("HeaderActiveForeground");
            _bindigHeaderActiveForeground.Source = canvasButtonSettings;


            _header = new Grid();
            _header.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100.0, GridUnitType.Star) });
            _header.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0, GridUnitType.Auto) });
            _header.SetBinding(Grid.BackgroundProperty, _bindingHeaderBackgroundBrush);

            _textBlockCaption = new TextBlock() { Text = "Window " + index };
            _textBlockCaption.SetBinding(TextBlock.ForegroundProperty, _bindigHeaderForeground);
            _textBlockCaption.Padding = new Thickness(5, 2, 0, 3);
            _textBlockCaption.TextTrimming = TextTrimming.CharacterEllipsis;

            var closeButtonIcon = FindResource("Ovotan_Control_DockPanel_Settings_ButtonIconClose") as Geometry;
            var closeButton = new IconButton();
            closeButton.Click += (x, y) => _panelClosed();
            closeButton.Icon = closeButtonIcon;
            closeButton.HorizontalAlignment = HorizontalAlignment.Right;
            closeButton.Foreground = new SolidColorBrush(Colors.Black);
            //closeButton.MouseMove += CloseButton_MouseMove;
            closeButton.Margin = new Thickness(0, 0, 5, 0);
            closeButton.SetValue(Grid.ColumnProperty, 1);

            var pinButtonIcon = FindResource("Ovotan_Control_DockPanel_Settings_ButtonIconPin") as Geometry;
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
            if (dockPanelContent != null)
            {
                _stackPanel.Children.Add(dockPanelContent);
                _stackPanel.SetValue(StackPanel.BackgroundProperty, new SolidColorBrush(Colors.Red));
            }


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
                _header.SetBinding(Grid.BackgroundProperty, _bindingHeaderActiveBackgroundBrush);
                _textBlockCaption.SetBinding(TextBlock.ForegroundProperty, _bindigHeaderActiveForeground);
                _dockMessageQueue.Publish(DockingMessageType.PanelGotFocus, this);
            }
            if (!focusable && IsActive)
            {
                _header.SetBinding(Grid.BackgroundProperty, _bindingHeaderBackgroundBrush);
                _textBlockCaption.SetBinding(TextBlock.ForegroundProperty, _bindigHeaderForeground);
                IsActive = false;
            }
        }

        void _panelClosed()
        {
            _dockMessageQueue.Publish(DockingMessageType.PanelClosed, this);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _buttonHandlers(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var args = new PanelSplittedMessage() { PanelSplitted = this, SplitType = (PanelSplittedType)button.CommandParameter };
            _dockMessageQueue.Publish(DockingMessageType.PanelSplitted, args);
        }
    }
}



//dockingManagerSetting.SetValue(DockingManagerSetting.DockGridContentHeader_Background_Property, new SolidColorBrush(Colors.Red));
// dockingManagerSetting.SetValue(DockingManagerSetting.DockGridContentHeader_Foreground_Property, new SolidColorBrush(Colors.Black));
//_textBlockCaption.Background

