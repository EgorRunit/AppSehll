using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AppShell.Controls.UI
{
    public interface IDockPanelGrid
    {
        UIElementCollection Children { get; }
    }

    public class BaseDockGrid : Grid, IDockPanelGrid
    {
        public BaseDockGrid(FrameworkElement baseContent)
        {
            RowDefinitions.Add(new RowDefinition());
            ColumnDefinitions.Add(new ColumnDefinition());
            Children.Add(baseContent);
        }
    }


    public class DockGridHorizontal : Grid, IDockPanelGrid
    {
        internal DockGridHorizontal()
        {
            ShowGridLines = true;
            RowDefinitions.Add(new RowDefinition());
            ColumnDefinitions.Add(new ColumnDefinition());
            ColumnDefinitions.Add(new ColumnDefinition());
        }

        public DockGridHorizontal(SnapPanelType type, double addedSize, FrameworkElement previosContent, FrameworkElement addedContent)
            : this()
        {
            switch (type)
            {
                case SnapPanelType.Left:
                    ColumnDefinitions[0].Width = new GridLength(addedSize, GridUnitType.Pixel);
                    ColumnDefinitions[1].Width = new GridLength(100, GridUnitType.Star);
                    addedContent.SetValue(Grid.ColumnProperty, 0);
                    previosContent.SetValue(Grid.ColumnProperty, 1);
                    Children.Add(addedContent);
                    Children.Add(previosContent);
                    break;
                case SnapPanelType.Right:
                    ColumnDefinitions[0].Width = new GridLength(100, GridUnitType.Star);
                    ColumnDefinitions[1].Width = new GridLength(addedSize, GridUnitType.Pixel);
                    previosContent.SetValue(Grid.ColumnProperty, 0);
                    addedContent.SetValue(Grid.ColumnProperty, 1);
                    Children.Add(previosContent);
                    Children.Add(addedContent);
                    break;
                default:
                    throw new Exception("eeeeeeeeeeee");
            }
        }
    }
}
