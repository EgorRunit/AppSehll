using Ovotan.ApplicationShell.Controls.Interfaces;
using Ovotan.Controls.Docking;
using Ovotan.Controls.Docking.Enums;
using Ovotan.Controls.Docking.Interfaces;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Ovotan.ApplicationShell.Controls
{


    public class EndPointManagement : ContentControl
    {
        public static readonly DependencyProperty HeadMenuItemsProperty;


        Grid _mainGrid;
        Menu _mainMenu;

        IDockingMessageQueue _dockingMessageQueue;
        Dictionary<Type, EndPointManager> _shells;
        DockingHost _dockingHost;
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



        static EndPointManagement()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EndPointManagement), new FrameworkPropertyMetadata(typeof(EndPointManagement)));

            HeadMenuItemsProperty = DependencyProperty.Register("Icon", typeof(ObservableCollection<MenuItem>), typeof(EndPointManagement),
                new FrameworkPropertyMetadata(new ObservableCollection<MenuItem>(), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
        }

        public EndPointManagement() 
        {

            _dockingMessageQueue = new DockingMessageQueue();
            _headMenuItems = new ObservableCollection<MenuItem>();
            _shells = new Dictionary<Type, EndPointManager>();
            _dockingHost = new DockingHost(_dockingMessageQueue);
            _dockingHost.SetValue(Grid.RowProperty, 1);
            _dockingHost.Loaded += _dockingHost_Loaded;

        }

        private void _dockingHost_Loaded(object sender, RoutedEventArgs e)
        {
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
            EndPointManager endPoint = null;
            if (_shells.ContainsKey(shellType))
            {
                 endPoint = _shells [shellType];
            }
            else
            {
                endPoint = Activator.CreateInstance(shellType) as EndPointManager;
            }
            endPoint.Start(_dockingMessageQueue);
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



        public EndPointManager AutoStartShell { get; set; }

    }
}