using Ovotan.Controls.Docking.Enums;
using Ovotan.Controls.Docking.Interfaces;
using Ovotan.Controls.Docking.Settings;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Ovotan.Controls.Docking
{
    public class PanelVerticalContainer : Grid, IDockPanelContainer
    {
        public PanelVerticalContainer(PanelSplittedType type, double addedSize, FrameworkElement previosContent, FrameworkElement addedContent)
        {
            var panelSettings = FindResource("Ovotan_Control_DockPanel_Settings") as PanelSettings;
            var bindigSplitterBackground = new Binding("SplitterBackground");
            bindigSplitterBackground.Source = panelSettings;
            RowDefinitions.Add(new RowDefinition());
            RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0, GridUnitType.Auto)});
            RowDefinitions.Add(new RowDefinition());
            ColumnDefinitions.Add(new ColumnDefinition());
            var splitter = new GridSplitter()
            {
                Height = 5,
                Background = new SolidColorBrush(Colors.Red),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
                ResizeDirection = GridResizeDirection.Rows

            };
            SetRow(splitter, 1);
            splitter.SetBinding(BackgroundProperty, bindigSplitterBackground);
            Children.Add(splitter);

            switch (type)
            {
                case PanelSplittedType.Top:
                    RowDefinitions[0].Height = new GridLength(addedSize, GridUnitType.Pixel);
                    RowDefinitions[2].Height = new GridLength(100, GridUnitType.Star);
                    addedContent.SetValue(RowProperty, 0);
                    previosContent.SetValue(RowProperty, 2);
                    Children.Add(addedContent);
                    Children.Add(previosContent);
                    break;
                case PanelSplittedType.Bottom:
                    RowDefinitions[0].Height = new GridLength(100, GridUnitType.Star);
                    RowDefinitions[2].Height = new GridLength(addedSize, GridUnitType.Pixel);
                    previosContent.SetValue(RowProperty, 0);
                    addedContent.SetValue(RowProperty, 2);
                    Children.Add(previosContent);
                    Children.Add(addedContent);
                    break;
                default:
                    throw new Exception("eeeeeeeeeeee");
            }
        }
    }
}
