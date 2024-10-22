
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
    public class ObjectBrowserNodeaaaaaaa : TreeViewItem
    {
        public static readonly DependencyProperty TreeNodeProperty;
        public string Text { get; set; }
        public ObservableCollection<ObjectBrowserNode> Children { get; set; }

        public object TreeNode
        {
            get
            {
                return GetValue(TreeNodeProperty);
            }
            set
            {
                SetValue(TreeNodeProperty, value);
            }
        }



        public ObjectBrowserNodeaaaaaaa() 
        { 
            Children = new ObservableCollection<ObjectBrowserNode>();
        }

        //public static DependencyProperty TextProperty;
        //public static DependencyProperty ChildrenProperty;
        public static DependencyProperty HasItemsProperty;
        public static DependencyProperty HasHeaderProperty;

        //public TreeNodeType NodeType { get; set; }
        //public bool IsExpanded { get; set; }
        public bool HasHeader
        {
            get
            {
                return true;
                //new TreeViewItem().has
                //return (bool)GetValue(HasItemsProperty);
            }
            set
            {
                SetValue(HasItemsProperty, value);
            }
        }

        public bool HasItems
        {
            get
            {
                //new TreeViewItem().has
                return (bool)GetValue(HasItemsProperty);
            }
            set
            {
                SetValue(HasItemsProperty, value);
            }
        }


        //public string Text 
        //{  
        //    get
        //    {
        //        return GetValue(TextProperty) as string;
        //    }
        //    set 
        //    { 
        //        SetValue(TextProperty, value); 
        //    }
        //}

        //public ObservableCollection<ObjectBrowserNode> Childred
        //{
        //    get
        //    {
        //        return GetValue(ChildrenProperty) as ObservableCollection<ObjectBrowserNode>;
        //    }
        //    set
        //    {
        //        SetValue (ChildrenProperty, value);
        //    }
        //}

        //static ObjectBrowserNode()
        //{
        //    DefaultStyleKeyProperty.OverrideMetadata(typeof(ObjectBrowserNode), new FrameworkPropertyMetadata(typeof(ObjectBrowserNode)));
        //    //TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(ObjectBrowserNode),
        //    //    new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
        //    //ChildrenProperty = DependencyProperty.Register("Children", typeof(ObservableCollection<ObjectBrowserNode>), typeof(ObjectBrowserNode),
        //    //    new FrameworkPropertyMetadata(new ObservableCollection<ObjectBrowserNode>(), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
        //    HasItemsProperty = DependencyProperty.Register("HasItems", typeof(bool), typeof(ObjectBrowserNode),
        //        new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
        //    TreeNodeProperty = DependencyProperty.Register("TreeNode", typeof(object), typeof(ObjectBrowserNode),
        //        new FrameworkPropertyMetadata(new object(), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
        //}

    }

    public class ShellObjectBrowser : ContentControl
    {
        IShell _shell;
        ToolBar _toolBar;
        TreeView _treeView; 
        List<FrameworkElement> _toolbarElements;
        static DependencyProperty ChildrenProperty;


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
            if(element is AddGroupFolder)
            {
                var dialog = new AddGroupFolderDialog();
                dialog.Owner = Application.Current.MainWindow;
                dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                if (dialog.ShowDialog() == true)
                {
                    var sss = dialog.GroupFolderName.Text;
                }
            }
            else
            {
                //Children[0].ExpandSubtree();

                //Children.Add(new ObjectBrowserNode() { Text = "sdfsdfsd" });
                //  element.Action();
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _toolBar = Template.FindName("Toolbar", this) as ToolBar;
            _toolBar.ItemsSource = _toolbarElements;
            _treeView = Template.FindName("TreeView", this) as TreeView;


            Children.Add(new ObjectBrowserNode() { Header = "werewrew 1"});
            Children.Add(new ObjectBrowserNode() { Header = "werewrew 2"});
            Children.Add(new ObjectBrowserNode() { Header = "werewrew 2" });
            Children.Add(new ObjectBrowserNode() { Header = "werewrew 2" });
            Children.Add(new ObjectBrowserNode() { Header = "werewrew 2"});
            Children.Add(new ObjectBrowserNode() { Header = "werewrew 2" });
            //Children[0].Items.Add(new ObjectBrowserNode() { Text = "dasfkds;lfk;dlsfk;lsdkf;lds" });
            //(Children[0] as TreeViewItem).Items[0].Add(new ObjectBrowserNode() { Text = "33333" });


            Children[0].Items.Add(new ObjectBrowserNode() { Header="childred"});
            (Children[0].Items[0] as TreeViewItem) .Items.Add(new ObjectBrowserNode() { Header = "childred" });
            Children[3].Items.Add(new ObjectBrowserNode() { Header = "childred" });
            //           .Childred.Add(new ObjectBrowserNode() { Text = "xsfsdfsdfds" });

            //var node1 = new TreeViewItem() { Header = "1111111" };
            //node1.Items.Add(new TreeViewItem() { Header = "222222" });
            //_treeView.Items.Add(node1);
            //var binding = new Binding("Nodes");
            //binding.Source = this;
            //_treeView.SetBinding(TreeView.ItemsSourceProperty, binding);

            //_treeView.SetValue(TreeView.ItemsSourceProperty, Children);
            //_treeView.ItemsSource = Children;
            //var ss = Application.Current.Resources["EEE"] as DataTemplate;
            //_treeView.ItemTemplate = ss;
            //ItemsSource="{Binding Nodes, RelativeSource={RelativeSource TemplatedParent}}"
        }

    }

}
