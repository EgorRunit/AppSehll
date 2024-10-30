using doc = Ovotan.Windows.Controls.Docking;
using Ovotan.Windows.Controls.Docking.Interfaces;
using Ovotan.Windows.Controls.EndPointManagement.Configurations;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Ovotan.Windows.Controls.Docking;
using Ovotan.Windows.Controls.Docking.Enums;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

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

            SchemaManager.AddResource("pack://application:,,,/Ovotan.Windows.Controls.EndPointManagement;component/Schemas/{Schemas}/DialogResource.xaml", "{Schemas}");
            SchemaManager.AddResource("pack://application:,,,/Ovotan.Windows.Controls.EndPointManagement;component/Schemas/{Schemas}/SiteHostDocumentDataGridResource.xaml", "{Schemas}");
            SchemaManager.AddResource("pack://application:,,,/Ovotan.Windows.Controls.EndPointManagement;component/Schemas/{Schemas}/ToolbarResource.xaml", "{Schemas}");
        }

        public Management() : this(new EndPointConfigurations("EndPoint Management"))
        {
        }


        MenuItem _menuItemView;
        MenuItem _menuItemTools;
        public Management(EndPointConfigurations configurationManager) 
        {
            _configurationManager = configurationManager;
            _dockingMessageQueue = new DockingMessageQueue();
            _headMenuItems = new ObservableCollection<MenuItem>();
            _endPoints = new Dictionary<Type, Manager>();
            _dockingHost = new DockingHost(_dockingMessageQueue);
            _dockingHost.SetValue(Grid.RowProperty, 1);
            _dockingHost.Loaded += _dockingHost_Loaded;
            _dockingMessageQueue.Register(DockingMessageType.PanelClosed, (x) => _panelClosed(x as doc.DockPanel));


            _menuItemView = new MenuItem() { Header = "View" };
            _menuItemTools = new MenuItem() { Header = "Tools" };

            HeadMenuItems.Add(_menuItemView);
            HeadMenuItems.Add(_menuItemTools);

        }

        void _panelClosed(doc.DockPanel message)
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
                StartEndPoint(AutoStartShell.GetType());
            }
        }

        public void AddHeadMenuItem(string title, Guid itemId)
        {
            var menuItem = new MenuItem() { Header = title, Tag = itemId };
        }

        public void StartEndPoint(Type shellType)
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

            endPoint.Start(_dockingHost.SiteHost, _configurationManager, _dockingMessageQueue);
            _menuItemView.ItemsSource = endPoint.MenuViewItems;
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
