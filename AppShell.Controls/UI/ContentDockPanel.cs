using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace AppShell.Controls.UI
{
    public class ContentDockPanel : Grid
    {
        TextBlock _textBlockCaption;
        StackPanel _stackPanel;
        Button _right;
        Button _top;
        Button _left;
        Button _bottom;
        Action<ContentDockPanel, SnapPanelType> _action;
        static int index = 0;


        internal ContentDockPanel(Action<ContentDockPanel, SnapPanelType> action)
        {
            _action = action;
            RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0.0, GridUnitType.Auto) });
            RowDefinitions.Add(new RowDefinition() { Height = new GridLength(100.0, GridUnitType.Star) });
            RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0.0, GridUnitType.Auto) });
            ColumnDefinitions.Add(new ColumnDefinition());

            index++;
            _textBlockCaption = new TextBlock() { Text = "Window " + index  };
            _stackPanel = new StackPanel();
            _stackPanel.SetValue(Grid.RowProperty, 1);

            _right = new Button() { Content = "right", CommandParameter = SnapPanelType.Right };
            _right.Click += _right_Click;

            _left = new Button() { Content = "left", CommandParameter = SnapPanelType.Left };
            _left.Click += _right_Click;

            _top = new Button() { Content = "top", CommandParameter = SnapPanelType.Top };
            _top.Click += _right_Click;

            _bottom = new Button() { Content = "bottom", CommandParameter = SnapPanelType.Bottom };
            _bottom.Click += _right_Click;

            _textBlockCaption.SetValue(Grid.RowProperty, 0);
            _stackPanel.Children.Add(_left);
            _stackPanel.Children.Add(_right);
            _stackPanel.Children.Add(_top);
            _stackPanel.Children.Add(_bottom);
            Children.Add(_textBlockCaption);
            Children.Add(_stackPanel);
            if (index > 1)
            {
                Background = new SolidColorBrush(Colors.Aqua);
            }
        }


        private void _right_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var type = (SnapPanelType)button.CommandParameter;
            _action(this, type);
        }
    }
}
