using System.Windows;
using System.Windows.Media;

namespace Ovotan.ApplicationShell.Controls.Settings
{
    public class EndPointSettings : DependencyObject
    {
        public static DependencyProperty SelectedBackgroundProperty;
        public static DependencyProperty SelectedUnfocusedColorProperty;

        public static DependencyProperty TreeArrowStaticCheckedFillProperty;
        public static DependencyProperty TreeArrowStaticCheckedStrokeProperty;
        public static DependencyProperty TreeArrowMouseOverCheckedStrokeProperty;

        /// <summary>
        /// Цвет фона указателя раскрытия узла (открытом состоянии).
        /// </summary>
        public static DependencyProperty TreeArrowMouseOverCheckedFillProperty;
        public static DependencyProperty TreeArrowMouseOverStrokeProperty;
        public static DependencyProperty TreeArrowMouseOverFillProperty;

        /// <summary>
        /// Цвет фона укзателя раскрытия узла (в закрытом состонии).
        /// </summary>
        public static DependencyProperty TreeArrowStaticFillProperty;
        public static DependencyProperty TreeArrowStaticStrokeProperty;
        public static DependencyProperty SelectedBackgroundColorProperty;

        #region properties
        public SolidColorBrush SelectedBackgroundColor
        {
            get
            {
                return GetValue(SelectedBackgroundColorProperty) as SolidColorBrush;
            }
            set
            {
                SetValue(SelectedBackgroundColorProperty, value);
            }
        }


        public SolidColorBrush TreeArrowStaticStroke
        {
            get
            {
                return GetValue(TreeArrowStaticStrokeProperty) as SolidColorBrush;
            }
            set
            {
                SetValue(TreeArrowStaticStrokeProperty, value);
            }
        }


        public SolidColorBrush TreeArrowStaticFill
        {
            get
            {
                return GetValue(TreeArrowStaticFillProperty) as SolidColorBrush;
            }
            set
            {
                SetValue(TreeArrowStaticFillProperty, value);
            }
        }

        public SolidColorBrush TreeArrowMouseOverFill
        {
            get
            {
                return GetValue(TreeArrowMouseOverFillProperty) as SolidColorBrush;
            }
            set
            {
                SetValue(TreeArrowMouseOverFillProperty, value);
            }
        }

        public SolidColorBrush TreeArrowMouseOverStroke
        {
            get
            {
                return GetValue(TreeArrowMouseOverStrokeProperty) as SolidColorBrush;
            }
            set
            {
                SetValue(TreeArrowMouseOverStrokeProperty, value);
            }
        }


        public SolidColorBrush TreeArrowMouseOverCheckedFill
        {
            get
            {
                return GetValue(TreeArrowMouseOverCheckedFillProperty) as SolidColorBrush;
            }
            set
            {
                SetValue(TreeArrowMouseOverCheckedFillProperty, value);
            }
        }

        public SolidColorBrush TreeArrowMouseOverCheckedStroke
        {
            get
            {
                return GetValue(TreeArrowMouseOverCheckedStrokeProperty) as SolidColorBrush;
            }
            set
            {
                SetValue(TreeArrowMouseOverCheckedStrokeProperty, value);
            }
        }

        public SolidColorBrush TreeArrowStaticCheckedStroke
        {
            get
            {
                return GetValue(TreeArrowStaticCheckedStrokeProperty) as SolidColorBrush;
            }
            set
            {
                SetValue(TreeArrowStaticCheckedStrokeProperty, value);
            }
        }

        public SolidColorBrush TreeArrowStaticCheckedFill
        {
            get
            {
                return GetValue(TreeArrowStaticCheckedFillProperty) as SolidColorBrush;
            }
            set
            {
                SetValue(TreeArrowStaticCheckedFillProperty, value);
            }
        }

        public Color SelectedUnfocusedColor
        {
            get
            {
                return (GetValue(SelectedUnfocusedColorProperty) as SolidColorBrush).Color;
            }
            set
            {
                SetValue(SelectedUnfocusedColorProperty, value);
            }
        }

        public Color SelectedBackground
        {
            get
            {
                return (GetValue(SelectedBackgroundProperty) as SolidColorBrush).Color;
            }
            set
            {
                SetValue(SelectedBackgroundProperty, value);
            }
        }
        #endregion

        static EndPointSettings()
        {
            TreeArrowStaticCheckedFillProperty = DependencyProperty.Register("TreeArrowStaticCheckedFill", typeof(SolidColorBrush), typeof(EndPointSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            TreeArrowStaticCheckedStrokeProperty = DependencyProperty.Register("TreeArrowStaticCheckedStroke", typeof(SolidColorBrush), typeof(EndPointSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            TreeArrowMouseOverCheckedStrokeProperty = DependencyProperty.Register("TreeArrowMouseOverCheckedStroke", typeof(SolidColorBrush), typeof(EndPointSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            TreeArrowMouseOverCheckedFillProperty = DependencyProperty.Register("TreeArrowMouseOverCheckedFill", typeof(SolidColorBrush), typeof(EndPointSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            TreeArrowMouseOverStrokeProperty = DependencyProperty.Register("TreeArrowMouseOverStroke", typeof(SolidColorBrush), typeof(EndPointSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            TreeArrowMouseOverFillProperty = DependencyProperty.Register("TreeArrowMouseOverFill", typeof(SolidColorBrush), typeof(EndPointSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            TreeArrowStaticFillProperty = DependencyProperty.Register("TreeArrowStaticFill", typeof(SolidColorBrush), typeof(EndPointSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            TreeArrowStaticStrokeProperty = DependencyProperty.Register("TreeArrowStaticStroke", typeof(SolidColorBrush), typeof(EndPointSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            SelectedBackgroundColorProperty = DependencyProperty.Register("SelectedBackgroundColor", typeof(SolidColorBrush), typeof(EndPointSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));

            SelectedUnfocusedColorProperty = DependencyProperty.Register("SelectedUnfocusedColor", typeof(Color), typeof(EndPointSettings),
                new FrameworkPropertyMetadata(Color.FromRgb(0,0,0), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            SelectedBackgroundProperty = DependencyProperty.Register("SelectedBackground", typeof(Color), typeof(EndPointSettings),
                new FrameworkPropertyMetadata(Color.FromRgb(0, 0, 0), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));

        }
    }
}
