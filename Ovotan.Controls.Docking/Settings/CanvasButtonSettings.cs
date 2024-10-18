using System.Windows.Media;
using System.Windows;

namespace Ovotan.Controls.Docking.Settings
{
    /// <summary>
    /// /Класс настроек для цветовой схемы элемента управления CanvasButton.
    /// </summary>
    public class CanvasButtonSettings : FrameworkElement
    {
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
        /// Зависимое свойство. Цвет заливки при наведении курсора мыши.
        /// </summary>
        public static readonly DependencyProperty OverFill1Property;
        /// <summary>
        /// Зависимое свойство. Цвет заливки при наведении курсора мыши.
        /// </summary>
        public static readonly DependencyProperty OverFill2Property;
        /// <summary>
        /// Зависимое свойство. Цвет заливки при наведении курсора мыши.
        /// </summary>
        public static readonly DependencyProperty OverFill3Property;
        /// <summary>
        /// Зависимое свойство. Цвет линии при наведении курсора мыши.
        /// </summary>
        public static readonly DependencyProperty OverStroke1Property;
        /// <summary>
        /// Зависимое свойство. Цвет линии при наведении курсора мыши.
        /// </summary>
        public static readonly DependencyProperty OverStroke2Property;
        /// <summary>
        /// Зависимое свойство. Цвет линии при наведении курсора мыши.
        /// </summary>
        public static readonly DependencyProperty OverStroke3Property;

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


        /// <summary>
        /// Get,Set - Цвет заливки при наведении мыши.
        /// </summary>
        public SolidColorBrush OverFill1
        {
            get
            {

                return GetValue(OverFill1Property) as SolidColorBrush;
            }
            set
            {
                SetValue(OverFill1Property, value);
            }
        }
        
        /// <summary>
        /// Get,Set - Цвет заливки при наведении мыши.
        /// </summary>
        public SolidColorBrush OverFill2
        {
            get
            {

                return GetValue(OverFill2Property) as SolidColorBrush;
            }
            set
            {
                SetValue(OverFill2Property, value);
            }
        }
        
        /// <summary>
        /// Get,Set - Цвет заливки при наведении мыши.
        /// </summary>
        public SolidColorBrush OverFill3
        {
            get
            {

                return GetValue(OverFill3Property) as SolidColorBrush;
            }
            set
            {
                SetValue(OverFill3Property, value);
            }
        }

        /// <summary>
        /// Get,Set - Цвет злинии при наведении мыши.
        /// </summary>
        public SolidColorBrush OverStroke1
        {
            get
            {
                return GetValue(OverStroke1Property) as SolidColorBrush;
            }
            set
            {
                SetValue(OverStroke1Property, value);
            }
        }

        /// <summary>
        /// Get,Set - Цвет злинии при наведении мыши.
        /// </summary>
        public SolidColorBrush OverStroke2
        {
            get
            {
                return GetValue(OverStroke2Property) as SolidColorBrush;
            }
            set
            {
                SetValue(OverStroke2Property, value);
            }
        }

        /// <summary>
        /// Get,Set - Цвет злинии при наведении мыши.
        /// </summary>
        public SolidColorBrush OverStroke3
        {
            get
            {
                return GetValue(OverStroke3Property) as SolidColorBrush;
            }
            set
            {
                SetValue(OverStroke3Property, value);
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        static CanvasButtonSettings()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CanvasButtonSettings), new FrameworkPropertyMetadata(typeof(CanvasButtonSettings)));

            Fill1Property = DependencyProperty.Register("Fill1", typeof(SolidColorBrush), typeof(CanvasButtonSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            Fill2Property = DependencyProperty.Register("Fill2", typeof(SolidColorBrush), typeof(CanvasButtonSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            Fill3Property = DependencyProperty.Register("Fill3", typeof(SolidColorBrush), typeof(CanvasButtonSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            Stroke1Property = DependencyProperty.Register("Stroke1", typeof(SolidColorBrush), typeof(CanvasButtonSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            Stroke2Property = DependencyProperty.Register("Stroke2", typeof(SolidColorBrush), typeof(CanvasButtonSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            Stroke3Property = DependencyProperty.Register("Stroke3", typeof(SolidColorBrush), typeof(CanvasButtonSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            OverFill1Property = DependencyProperty.Register("OverFill1", typeof(SolidColorBrush), typeof(CanvasButtonSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            OverFill2Property = DependencyProperty.Register("OverFill2", typeof(SolidColorBrush), typeof(CanvasButtonSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            OverFill3Property = DependencyProperty.Register("OverFill3", typeof(SolidColorBrush), typeof(CanvasButtonSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            OverStroke1Property = DependencyProperty.Register("OverStroke1", typeof(SolidColorBrush), typeof(CanvasButtonSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            OverStroke2Property = DependencyProperty.Register("OverStroke2", typeof(SolidColorBrush), typeof(CanvasButtonSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            OverStroke3Property = DependencyProperty.Register("OverStroke3", typeof(SolidColorBrush), typeof(CanvasButtonSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
        }
    }
}
