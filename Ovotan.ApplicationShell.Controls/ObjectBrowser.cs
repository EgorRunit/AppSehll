
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

    public class ObjectBrowser : ContentControl
    {
        //IEndPoint _shell;
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

        static ObjectBrowser()
        {
            
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ObjectBrowser), new FrameworkPropertyMetadata(typeof(ObjectBrowser)));
            //ChildrenProperty = DependencyProperty.Register("Children", typeof(ObservableCollection<ObjectBrowserNode>), typeof(ShellObjectBrowser),
            //    new FrameworkPropertyMetadata(new ObservableCollection<ObjectBrowserNode>(), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));

        }


        public ObjectBrowser(EndPointManager shell)
        {
            ////new TreeViewItem().HasItems
            //Children = new ObservableCollection<ObjectBrowserNode>();
            //_toolbarElements = new List<FrameworkElement>();
            //_shell = shell;
            //foreach (var element in _shell.ObjectBrowserToolbarElements)
            //{
            //    switch (element.Type)
            //    {
            //        case ShellToolbarElementType.Button:
            //            var button =  new Button() { Content = element.Text, Tag = element };
            //            button.Click += Button_Click;
            //            _toolbarElements.Add(button);
            //            break;
            //    }
            //}

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
