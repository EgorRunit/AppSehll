using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using Ovotan.Controls.Docking.Enums;

namespace Ovotan.Controls.Docking
{
    /// <summary>
    /// Эелемента управления кнопка.
    /// Основывется на шаблоне ControlTemplate в котором настроен Canvas.
    /// </summary>
    public class CanvasButton : ContentControl
    {
        /// <summary>
        /// Зависимое свойство. Тип шаблона для кнопки.
        /// </summary>
        public static readonly DependencyProperty CanvasButtonTypeProperty;
        /// <summary>
        /// Зависимое свойство. Цвет заливки в о бычном состоянии.
        /// </summary>
        public static readonly DependencyProperty Fill1Property;
        /// <summary>
        /// Зависимое свойство. Цвет заливки в о бычном состоянии.
        /// </summary>
        public static readonly DependencyProperty Fill2Property;
        /// <summary>
        /// Зависимое свойство. Цвет заливки в о бычном состоянии.
        /// </summary>
        public static readonly DependencyProperty Fill3Property;
        /// <summary>
        /// Зависимое свойство. Цвет линии в обычном состоянии.
        /// </summary>
        public static readonly DependencyProperty Stroke1Property;
        /// <summary>
        /// Зависимое свойство. Цвет линии в обычном состоянии.
        /// </summary>
        public static readonly DependencyProperty Stroke2Property;
        /// <summary>
        /// Зависимое свойство. Цвет линии в обычном состоянии.
        /// </summary>
        public static readonly DependencyProperty Stroke3Property;

        /// <summary>
        /// Get,Set - тип шаблона для кнопки.
        /// </summary>
        public CanvasButtonType CanvasButtonType
        {
            get
            {
                return (CanvasButtonType)GetValue(CanvasButtonTypeProperty);
            }
            set
            {
                SetValue(CanvasButtonTypeProperty, value);
            }
        }


        /// <summary>
        /// Get,Set - Цвет заливки в о бычном состоянии.
        /// </summary>
        public SolidColorBrush Fill1
        {
            get
            {

                return GetValue(Fill1Property) as SolidColorBrush;
            }
            set
            {
                SetValue(Fill1Property, value);
            }
        }

        /// <summary>
        /// Get,Set - Цвет заливки в о бычном состоянии.
        /// </summary>
        public SolidColorBrush Fill2
        {
            get
            {

                return GetValue(Fill2Property) as SolidColorBrush;
            }
            set
            {
                SetValue(Fill2Property, value);
            }
        }

        /// <summary>
        /// Get,Set - Цвет заливки в о бычном состоянии.
        /// </summary>
        public SolidColorBrush Fill3
        {
            get
            {

                return GetValue(Fill3Property) as SolidColorBrush;
            }
            set
            {
                SetValue(Fill3Property, value);
            }
        }


        /// <summary>
        /// Get,Set - Цвет злинии в обычном состоянии.
        /// </summary>
        public SolidColorBrush Stroke1
        {
            get
            {
                return GetValue(Stroke1Property) as SolidColorBrush;
            }
            set
            {
                SetValue(Stroke1Property, value);
            }
        }

        /// <summary>
        /// Get,Set - Цвет злинии в обычном состоянии.
        /// </summary>
        public SolidColorBrush Stroke2
        {
            get
            {
                return GetValue(Stroke2Property) as SolidColorBrush;
            }
            set
            {
                SetValue(Stroke2Property, value);
            }
        }

        /// <summary>
        /// Get,Set - Цвет злинии в обычном состоянии.
        /// </summary>
        public SolidColorBrush Stroke3
        {
            get
            {
                return GetValue(Stroke3Property) as SolidColorBrush;
            }
            set
            {
                SetValue(Stroke3Property, value);
            }
        }

        static CanvasButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CanvasButton), new FrameworkPropertyMetadata(typeof(Canvas)));

            CanvasButtonTypeProperty = DependencyProperty.Register("CanvasButtonType", typeof(CanvasButtonType), typeof(Canvas),
                new PropertyMetadata(CanvasButtonType.WindowTopDock));
            Fill1Property = DependencyProperty.Register("Fill1", typeof(SolidColorBrush), typeof(CanvasButton),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            Fill2Property = DependencyProperty.Register("Fill2", typeof(SolidColorBrush), typeof(CanvasButton),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            Fill3Property = DependencyProperty.Register("Fill3", typeof(SolidColorBrush), typeof(CanvasButton),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            Stroke1Property = DependencyProperty.Register("Stroke1", typeof(SolidColorBrush), typeof(CanvasButton),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            Stroke2Property = DependencyProperty.Register("Stroke2", typeof(SolidColorBrush), typeof(CanvasButton),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            Stroke3Property = DependencyProperty.Register("Stroke3", typeof(SolidColorBrush), typeof(CanvasButton),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
        }


        public override void OnApplyTemplate()
        {
            switch (CanvasButtonType)
            {
                case CanvasButtonType.WindowTopDock:
                    Template = Application.Current.Resources["Ovotan_Controls_Media_DockPlacementWindow_TopDock"] as ControlTemplate;
                    break;
                case CanvasButtonType.WindowBottomDock:
                    Template = Application.Current.Resources["Ovotan_Controls_Media_DockPlacementWindow_BottomDock"] as ControlTemplate;
                    break;
                case CanvasButtonType.WindowLeftDock:
                    Template = Application.Current.Resources["Ovotan_Controls_Media_DockPlacementWindow_LeftDock"] as ControlTemplate;
                    break;
                case CanvasButtonType.WindowRightDock:
                    Template = Application.Current.Resources["Ovotan_Controls_Media_DockPlacementWindow_RightDock"] as ControlTemplate;
                    break;
            }
            base.OnApplyTemplate();
        }
    }
}
