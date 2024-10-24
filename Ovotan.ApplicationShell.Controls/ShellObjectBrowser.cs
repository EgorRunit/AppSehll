
using Ovotan.ApplicationShell.Controls.Dialogs;
using Ovotan.ApplicationShell.Controls.Interfaces;
using Ovotan.ApplicationShell.Controls.ToolbarElements;
using Ovotan.Controls.Docking;
using Ovotan.Controls.Docking.Settings;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Ovotan.ApplicationShell.Controls
{

    public class ShellObjectBrowser : ContentControl
    {
        IShell _shell;
        ToolBar _toolBar;
        TreeView _treeView; 
        List<FrameworkElement> _toolbarElements;


        public ObservableCollection<ObjectBrowserNode> Children { get; set; }
        //{
            //get
            //{
            //    return GetValue(ChildrenProperty) as ObservableCollection<ObjectBrowserNode>;
            //}
            //set
            //{
            //    SetValue(ChildrenProperty, value);
            //}
        //}

        static ShellObjectBrowser()
        {
            
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ShellObjectBrowser), new FrameworkPropertyMetadata(typeof(ShellObjectBrowser)));
            //ChildrenProperty = DependencyProperty.Register("Children", typeof(ObservableCollection<ObjectBrowserNode>), typeof(ShellObjectBrowser),
            //    new FrameworkPropertyMetadata(new ObservableCollection<ObjectBrowserNode>(), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));

        }


        public ShellObjectBrowser(IShell shell)
        {
            //new TreeViewItem().HasItems
            Children = new ObservableCollection<ObjectBrowserNode>();
            _toolbarElements = new List<FrameworkElement>();
            _shell = shell;
            foreach (var element in _shell.ObjectBrowserToolbarElements)
            {
                switch (element.Type)
                {
                    case ShellToolbarElementType.Button:
                        var button =  new Button() { Content = element.Text, Tag = element };
                        button.Click += Button_Click;
                        _toolbarElements.Add(button);
                        break;
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var element = (sender as FrameworkElement).Tag as ToolbarElementBase;
            if (element is AddGroupFolder)
            {
                var dialog = new AddGroupFolderDialog();
                dialog.Owner = Application.Current.MainWindow;
                dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                if (dialog.ShowDialog() == true)
                {
                    var selectedNode = _treeView.SelectedItem as ObjectBrowserNode;
                    var newNode = new ObjectBrowserNode() { Header = dialog.GroupFolderName.Text };
                    if (selectedNode != null)
                    {
                        selectedNode.Items.Add(newNode);
                        selectedNode.ExpandSubtree();
                    }
                    else
                    {
                        Children.Add(newNode);
                    }
                }
            }
            else
            {
                //var wnd = new ConnectionManagement();// ("localhost");

                ////wnd.Owner = Application.Current.MainWindow;
                //wnd.Visibility = Visibility.Visible;
                //wnd.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                ////var wnd = new ConnectDialog();
                //wnd.Show();

                element.Action();

                //Children[0].ExpandSubtree();

                //Children.Add(new ObjectBrowserNode() { Header = "sdfsdfsd" });
                //Dispatcher.BeginInvoke(() => { element.Action(); } , System.Windows.Threading.DispatcherPriority.Render);


            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _toolBar = Template.FindName("Toolbar", this) as ToolBar;
            _toolBar.ItemsSource = _toolbarElements;
            _treeView = Template.FindName("TreeView", this) as TreeView;
            //_treeView.SetValue(TreeView.ItemsSourceProperty, Children);
            _treeView.ItemsSource = Children;
            //var ss = Application.Current.Resources["EEE"] as DataTemplate;
            //_treeView.ItemTemplate = ss;
            //ItemsSource="{Binding Nodes, RelativeSource={RelativeSource TemplatedParent}}"
        }

    }

}
