using AppShell.Controls.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AppShell.Controls.Settings
{
    public class DockPlacementWindowSettings : FrameworkElement
    {
        public static readonly DependencyProperty Fill1Property;
        public static readonly DependencyProperty Fill2Property;
        public static readonly DependencyProperty Fill3Property;
        public static readonly DependencyProperty Stroke1Property;
        public static readonly DependencyProperty Stroke2Property;
        public static readonly DependencyProperty Stroke3Property;

        public static readonly DependencyProperty OverFill1Property;
        public static readonly DependencyProperty OverFill2Property;
        public static readonly DependencyProperty OverFill3Property;
        public static readonly DependencyProperty OverStroke1Property;
        public static readonly DependencyProperty OverStroke2Property;
        public static readonly DependencyProperty OverStroke3Property;

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
        static DockPlacementWindowSettings()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DockPlacementWindowSettings), new FrameworkPropertyMetadata(typeof(DockPlacementWindowSettings)));

            Fill1Property = DependencyProperty.Register("Fill1", typeof(SolidColorBrush), typeof(DockPlacementWindowSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            Fill2Property = DependencyProperty.Register("Fill2", typeof(SolidColorBrush), typeof(DockPlacementWindowSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            Fill3Property = DependencyProperty.Register("Fill3", typeof(SolidColorBrush), typeof(DockPlacementWindowSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            Stroke1Property = DependencyProperty.Register("Stroke1", typeof(SolidColorBrush), typeof(DockPlacementWindowSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            Stroke2Property = DependencyProperty.Register("Stroke2", typeof(SolidColorBrush), typeof(DockPlacementWindowSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            Stroke3Property = DependencyProperty.Register("Stroke3", typeof(SolidColorBrush), typeof(DockPlacementWindowSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));

            OverFill1Property = DependencyProperty.Register("OverFill1", typeof(SolidColorBrush), typeof(DockPlacementWindowSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            OverFill2Property = DependencyProperty.Register("OverFill2", typeof(SolidColorBrush), typeof(DockPlacementWindowSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            OverFill3Property = DependencyProperty.Register("OverFill3", typeof(SolidColorBrush), typeof(DockPlacementWindowSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            OverStroke1Property = DependencyProperty.Register("OverStroke1", typeof(SolidColorBrush), typeof(DockPlacementWindowSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            OverStroke2Property = DependencyProperty.Register("OverStroke2", typeof(SolidColorBrush), typeof(DockPlacementWindowSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            OverStroke3Property = DependencyProperty.Register("OverStroke3", typeof(SolidColorBrush), typeof(DockPlacementWindowSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
        }

    }
}
