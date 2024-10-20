using Ovotan.Controls.Docking.Enums;
using Ovotan.Controls.Docking.Interfaces;
using Ovotan.Controls.Docking.Settings;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Ovotan.Controls.Docking
{
    public class PanelHorizontalContainer : Grid, IDockPanelContainer
    {
        public PanelHorizontalContainer(PanelSplittedType type, double addedSize, FrameworkElement previosContent, FrameworkElement addedContent)
        {
            var panelSettings = FindResource("Ovotan_Control_DockPanel_Settings") as PanelSettings;
            var bindigSplitterBackground = new Binding("SplitterBackground");
            bindigSplitterBackground.Source = panelSettings;

            RowDefinitions.Add(new RowDefinition());
            ColumnDefinitions.Add(new ColumnDefinition());
            ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0, GridUnitType.Auto) });
            ColumnDefinitions.Add(new ColumnDefinition());

            var splitter = new GridSplitter()
            {
                Width = 5,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Stretch
               
                
            };
            SetColumn(splitter, 1);
            splitter.SetBinding(BackgroundProperty, bindigSplitterBackground);
            Children.Add(splitter);
            switch (type)
            {
                case PanelSplittedType.Left:
                    ColumnDefinitions[0].Width = new GridLength(addedSize, GridUnitType.Pixel);
                    ColumnDefinitions[2].Width = new GridLength(100, GridUnitType.Star);
                    addedContent.SetValue(Grid.ColumnProperty, 0);
                    previosContent.SetValue(Grid.ColumnProperty, 2);
                    Children.Add(addedContent);
                    Children.Add(previosContent);
                    break;
                case PanelSplittedType.Right:
                    ColumnDefinitions[0].Width = new GridLength(100, GridUnitType.Star);
                    ColumnDefinitions[2].Width = new GridLength(addedSize, GridUnitType.Pixel);
                    previosContent.SetValue(Grid.ColumnProperty, 0);
                    addedContent.SetValue(Grid.ColumnProperty, 2);
                    Children.Add(previosContent);
                    Children.Add(addedContent);
                    break;
                default:
                    throw new Exception("eeeeeeeeeeee");
            }
        }
    }
}
