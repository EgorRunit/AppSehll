using Ovotan.Windows.Controls.Controls;
using Ovotan.Windows.Controls.Docking.Enums;
using Ovotan.Windows.Controls.Docking.Interfaces;
using Ovotan.Windows.Controls.Docking.Messages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ovotan.Windows.Controls.Docking
{
    public class DockPanel : ContentControl, IDockPanel
    {
        public static DependencyProperty IsPanelFocusedProperty;

        //Экземпляр очереди сообщений элметов докинга.
        IDockingMessageQueue _dockMessageQueue;
        //Экзямпляр грида структуры в шаблоне.
        Grid _panelGrid;

        public bool IsPanelFocused
        {
            get
            {
                return (bool)GetValue(IsPanelFocusedProperty);
            }
            set
            {
                //Нужно сделать передачу фокуса в содержимое
                if(DockPanelContent is IDockPanelContent)
                {
                    (DockPanelContent as IDockPanelContent).ContentFocus();
                }
                SetValue(IsPanelFocusedProperty, value);
            }
        }


        //Экземпляр вставляемого содержимого панели.
        public FrameworkElement DockPanelContent;
        public string Header { get; private set; }
        public ICommand CloseCommand { get; set; }
        public ICommand PinButton { get;set; }

        static DockPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DockPanel), new FrameworkPropertyMetadata(typeof(DockPanel)));
            IsPanelFocusedProperty = DependencyProperty.Register("IsPanelFocused", typeof(bool), typeof(DockPanel),
                new PropertyMetadata(false));



            //IsPanelFocusedProperty = DependencyProperty.Register("IsPanelFocused", typeof(bool), typeof(DockPanel),
            //    new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));

        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var header = Template.FindName("Header", this) as Grid;
            _panelGrid = Template.FindName("Panel", this) as Grid;

            if (!(DockPanelContent is ISiteHost))
            {
                if (DockPanelContent != null)
                {
                    DockPanelContent.SetValue(Grid.RowProperty, 1);
                    _panelGrid.Children.Add(DockPanelContent);
                }
            }
            else
            {
                DockPanelContent.SetValue(Grid.RowProperty, 0);
                _panelGrid.RowDefinitions.Clear();
                _panelGrid.Children.Clear();
                _panelGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(100.0, GridUnitType.Star) });
                _panelGrid.Children.Add(DockPanelContent);
            }

        }

        internal DockPanel(IDockingMessageQueue dockMessageQueue, FrameworkElement dockPanelContent)
        {
            Header = "Object browser";
            DockPanelContent = dockPanelContent;
            _dockMessageQueue = dockMessageQueue;
            CloseCommand = new ButtonCommand<object>(_ => _dockMessageQueue.Publish(DockingMessageType.PanelClosed, this));
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

