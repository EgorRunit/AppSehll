using System.Windows;
using System.Windows.Media;

namespace Ovotan.Controls.Docking.Settings
{
    /// <summary>
    /// Класс настроек хоста докинга.
    /// </summary>
    public class DockHositngSettings : FrameworkElement
    {
        /// <summary>
        /// Зависимое свойство. Цвет заливки хоста документов.
        /// </summary>
        public static readonly DependencyProperty SiteHostBackgroundProperty;


        /// <summary>
        /// Get,Set - Цвет заливки хоста документов.
        /// </summary>
        public SolidColorBrush SiteHostBackground
        {
            get
            {

                return GetValue(SiteHostBackgroundProperty) as SolidColorBrush;
            }
            set
            {
                SetValue(SiteHostBackgroundProperty, value);
            }
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        static DockHositngSettings()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DockHositngSettings), new FrameworkPropertyMetadata(typeof(DockHositngSettings)));

            SiteHostBackgroundProperty = DependencyProperty.Register("DocumentHostBackground", typeof(SolidColorBrush), typeof(DockHositngSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));

        }
    }
}
