using Ovotan.Controls.Docking.Enums;
using Ovotan.Controls.Docking.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace Ovotan.Controls.Docking
{
    public class PanelHorizontalContainer : Grid, IDockPanelContainer
    {
        internal PanelHorizontalContainer()
        {
            ShowGridLines = true;
            RowDefinitions.Add(new RowDefinition());
            ColumnDefinitions.Add(new ColumnDefinition());
            ColumnDefinitions.Add(new ColumnDefinition());
        }

        public PanelHorizontalContainer(PanelSplittedType type, double addedSize, FrameworkElement previosContent, FrameworkElement addedContent)
            : this()
        {
            switch (type)
            {
                case PanelSplittedType.Left:
                    ColumnDefinitions[0].Width = new GridLength(addedSize, GridUnitType.Pixel);
                    ColumnDefinitions[1].Width = new GridLength(100, GridUnitType.Star);
                    addedContent.SetValue(Grid.ColumnProperty, 0);
                    previosContent.SetValue(Grid.ColumnProperty, 1);
                    Children.Add(addedContent);
                    Children.Add(previosContent);
                    break;
                case PanelSplittedType.Right:
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
