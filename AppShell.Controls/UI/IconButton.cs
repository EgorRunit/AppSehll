using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AppShell.Controls.UI
{
    public class IconButton : Button
    {
        public static readonly DependencyProperty IconWidthProperty;
        public static readonly DependencyProperty IconHeightProperty;
        public static readonly DependencyProperty IconProperty;


        public ControlTemplate Icon
        {
            get
            {
                return GetValue(IconProperty) as ControlTemplate;
            }
            set
            {
                SetValue(IconProperty, value);
            }
        }

        public double IconWidth
        {
            get { return (double)GetValue(IconWidthProperty); }
            set { SetValue(IconWidthProperty, value); }
        }

        public double IconHeight
        {
            get { return (double)GetValue(IconHeightProperty); }
            set { SetValue(IconHeightProperty, value); }
        }


        static IconButton()
        {
            IconProperty = DependencyProperty.Register("Icon", typeof(ControlTemplate), typeof(IconButton),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));

            IconWidthProperty = DependencyProperty.Register("IconWidth", typeof(double), typeof(IconButton),
                new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));

            IconHeightProperty = DependencyProperty.Register("IconHeight", typeof(double), typeof(IconButton),
                new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
        }

        public IconButton() 
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IconButton), new FrameworkPropertyMetadata(typeof(IconButton)));
            Loaded += DialogWindowBase_Loaded;
        }
        private void DialogWindowBase_Loaded(object sender, RoutedEventArgs e)
        {
            var ss = Template.FindName("ButtonIconSpin", this);
            //var ssss = ss.FindName("SSSS");
        }
    }
}
