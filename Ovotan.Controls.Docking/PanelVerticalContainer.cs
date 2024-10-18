using Ovotan.Controls.Docking.Enums;
using Ovotan.Controls.Docking.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace Ovotan.Controls.Docking
{
    public class PanelVerticalContainer : Grid, IDockPanelContainer
    {
        public PanelVerticalContainer(PanelSplittedType type, double addedSize, FrameworkElement previosContent, FrameworkElement addedContent)
        {
            ShowGridLines = true;
            RowDefinitions.Add(new RowDefinition());
            RowDefinitions.Add(new RowDefinition());
            ColumnDefinitions.Add(new ColumnDefinition());
            switch (type)
            {
                case PanelSplittedType.Top:
                    RowDefinitions[0].Height = new GridLength(addedSize, GridUnitType.Pixel);
                    RowDefinitions[1].Height = new GridLength(100, GridUnitType.Star);
                    addedContent.SetValue(RowProperty, 0);
                    previosContent.SetValue(RowProperty, 1);
                    Children.Add(addedContent);
                    Children.Add(previosContent);
                    break;
                case PanelSplittedType.Bottom:
                    RowDefinitions[0].Height = new GridLength(100, GridUnitType.Star);
                    RowDefinitions[1].Height = new GridLength(addedSize, GridUnitType.Pixel);
                    previosContent.SetValue(RowProperty, 0);
                    addedContent.SetValue(RowProperty, 1);
                    Children.Add(previosContent);
                    Children.Add(addedContent);
                    break;
                default:
                    throw new Exception("eeeeeeeeeeee");
            }
        }
    }
}
