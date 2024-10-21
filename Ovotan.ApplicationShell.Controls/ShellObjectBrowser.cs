
using Ovotan.ApplicationShell.Controls.Interfaces;
using Ovotan.Controls.Docking.Settings;
using System.Windows;
using System.Windows.Controls;

namespace Ovotan.ApplicationShell.Controls
{
    public class ShellObjectBrowser : ContentControl
    {
        IShell _shell;
        ToolBar _toolBar;
        TreeView _treeView;
        List<FrameworkElement> _toolbarElements;


        static ShellObjectBrowser()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ShellObjectBrowser), new FrameworkPropertyMetadata(typeof(ShellObjectBrowser)));
        }


        public ShellObjectBrowser(IShell shell)
        {
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
            var element = (sender as FrameworkElement).Tag as ShellToolbarElement;
            element.Callback();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _toolBar = Template.FindName("Toolbar", this) as ToolBar;
            _toolBar.ItemsSource = _toolbarElements;
            _treeView = Template.FindName("TreeView", this) as TreeView;
        }
    }

}
