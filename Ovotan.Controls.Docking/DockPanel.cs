using Ovotan.Controls.Docking.Enums;
using Ovotan.Controls.Docking.Interfaces;
using Ovotan.Controls.Docking.Messages;
using Ovotan.Windows.Common.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ovotan.Controls.Docking
{
    public class DockPanel : ContentControl, IDockPanel
    {
        //Экземпляр очереди сообщений элметов докинга.
        IDockingMessageQueue _dockMessageQueue;
        //Экзямпляр грида структуры в шаблоне.
        Grid _panelGrid;
        //Экземпляр вставляемого содержимого панели.
        FrameworkElement _dockPanelContent;

        public string Header { get; private set; }

        public ICommand CloseCommand { get; set; }
        public ICommand PinButton { get;set; }

        static DockPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DockPanel), new FrameworkPropertyMetadata(typeof(DockPanel)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var header = Template.FindName("Header", this) as Grid;
            _panelGrid = Template.FindName("Panel", this) as Grid;
            _panelGrid.MouseDown += (x, x1) =>
            {
                FocusManager.SetFocusedElement(this,header);
                Focus();
            };

            if (!(_dockPanelContent is ISiteHost))
            {
                if (_dockPanelContent != null)
                {
                    _dockPanelContent.SetValue(Grid.RowProperty, 1);
                    _panelGrid.Children.Add(_dockPanelContent);
                }
            }
            else
            {
                _dockPanelContent.SetValue(Grid.RowProperty, 0);
                _panelGrid.RowDefinitions.Clear();
                _panelGrid.Children.Clear();
                //_panelGrid.RowDefinitions.RemoveAt(1);
                //_panelGrid.RowDefinitions.RemoveAt(1);

                _panelGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(100.0, GridUnitType.Star) });
                //_panelGrid.RowDefinitions.Add(new RowDefinition());
                _panelGrid.Children.Add(_dockPanelContent);
            }

        }

        internal DockPanel(IDockingMessageQueue dockMessageQueue, FrameworkElement dockPanelContent)
        {
            Header = "Object browser";
            _dockPanelContent = dockPanelContent;
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

