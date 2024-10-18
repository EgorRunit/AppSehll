using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System;

namespace AppShell.Controls.UI
{
    public class CanvasButton : ContentControl
    {
        public static readonly DependencyProperty Fill1Property;
        public static readonly DependencyProperty Fill2Property;
        public static readonly DependencyProperty Fill3Property;
        public static readonly DependencyProperty Stroke1Property;
        public static readonly DependencyProperty Stroke2Property;
        public static readonly DependencyProperty Stroke3Property;
        public static readonly DependencyProperty CanvasButtonTypeProperty;

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

        static CanvasButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CanvasButton), new FrameworkPropertyMetadata(typeof(Canvas)));

            CanvasButtonTypeProperty = DependencyProperty.Register("CanvasButtonType", typeof(CanvasButtonType), typeof(CanvasButton),
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


        public CanvasButton()
        {
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

        protected override void OnInitialized(EventArgs e)
        {

            base.OnInitialized(e);
        }



    }
}
