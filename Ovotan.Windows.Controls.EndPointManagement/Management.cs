using Ovotan.Controls.Docking;
using Ovotan.Controls.Docking.Enums;
using Ovotan.Controls.Docking.Interfaces;
using Ovotan.Windows.Controls.EndPointManagement.Configurations;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Ovotan.Windows.Controls.EndPointManagement
{


    public class Management : ContentControl
    {
        public static readonly DependencyProperty HeadMenuItemsProperty;


        Grid _mainGrid;
        Menu _mainMenu;

        IDockingMessageQueue _dockingMessageQueue;
        Dictionary<Type, Manager> _endPoints;
        DockingHost _dockingHost;
        EndPointConfigurations _configurationManager;
        ObservableCollection<MenuItem> _headMenuItems;

        public ObservableCollection<MenuItem> HeadMenuItems
        {
            get
            {
                return GetValue(HeadMenuItemsProperty) as ObservableCollection<MenuItem>;
            }
            set
            {
                SetValue(HeadMenuItemsProperty, value);
            }
        }



        static Management()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Management), new FrameworkPropertyMetadata(typeof(Management)));

            HeadMenuItemsProperty = DependencyProperty.Register("Icon", typeof(ObservableCollection<MenuItem>), typeof(Management),
                new FrameworkPropertyMetadata(new ObservableCollection<MenuItem>(), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
        }

        public Management() : this(new EndPointConfigurations("EndPoint Management"))
        {
        }

        public Management(EndPointConfigurations configurationManager) 
        {
            _configurationManager = configurationManager;
            _dockingMessageQueue = new DockingMessageQueue();
            _headMenuItems = new ObservableCollection<MenuItem>();
            _endPoints = new Dictionary<Type, Manager>();
            _dockingHost = new DockingHost(_dockingMessageQueue);
            _dockingHost.SetValue(Grid.RowProperty, 1);
            _dockingHost.Loaded += _dockingHost_Loaded;

            _dockingMessageQueue.Register(DockingMessageType.PanelClosed, (x) => _panelClosed(x as Ovotan.Controls.Docking.DockPanel));
        }

        void _panelClosed(Ovotan.Controls.Docking.DockPanel message)
        {
            var endPoint = message.DockPanelContent as Manager;
            if(endPoint != null)
            {
                if(_endPoints.ContainsKey(endPoint.GetType()))
                {
                    endPoint.SaveConfiguration();
                }
            }
        }


        private void _dockingHost_Loaded(object sender, RoutedEventArgs e)
        {
            //this.Template
            if (AutoStartShell != null)
            {
                StartShell(AutoStartShell.GetType());
            }
        }

        public void AddHeadMenuItem(string title, Guid itemId)
        {
            var menuItem = new MenuItem() { Header = title, Tag = itemId };
        }

        public void StartShell(Type shellType)
        {
            Manager endPoint = null;
            if (_endPoints.ContainsKey(shellType))
            {
                 endPoint = _endPoints [shellType];
            }
            else
            {
                endPoint = Activator.CreateInstance(shellType) as Manager;
                _endPoints.Add(shellType, endPoint);
            }
            endPoint.Start(_configurationManager, _dockingMessageQueue);
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _mainMenu  = Template.FindName("MainMenu", this) as Menu;
            _mainGrid = Template.FindName("MainGrid", this) as Grid;
            _mainGrid.Children.Add(_dockingHost);
            var binding = new Binding("HeadMenuItems");
            binding.Source = this;
            _mainMenu.SetBinding(Menu.ItemsSourceProperty, binding);

        }



        public Manager AutoStartShell { get; set; }

    }
}
