using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ovotan.Windows.Controls
{
    public class ViewboxIcon : ContentControl
    {
        public static readonly DependencyProperty ViewboxProperty;
        //public static readonly DependencyProperty FirstColorProperty;
        //public static readonly DependencyProperty SecondColorProperty;
        //public static readonly DependencyProperty MouseOverFirstColorProperty;
        //public static readonly DependencyProperty MouseOverSecondColorProperty;

        public SolidColorBrush FirstColor { get; set; }
        public SolidColorBrush SecondColor { get; set; }
        public SolidColorBrush MouseOverFirstColor { get; set; }
        public SolidColorBrush MouseOverSecondColor { get; set; }

        //public SolidColorBrush FirstColor
        //{
        //    get
        //    {
        //        return GetValue(FirstColorProperty) as SolidColorBrush;
        //    }
        //    set
        //    {
        //        SetValue(FirstColorProperty, value);
        //    }
        //}

        //public SolidColorBrush SecondColor
        //{
        //    get
        //    {
        //        return GetValue(SecondColorProperty) as SolidColorBrush;
        //    }
        //    set
        //    {
        //        SetValue(SecondColorProperty, value);
        //    }
        //}

        //public SolidColorBrush MouseOverFirstColor
        //{
        //    get
        //    {
        //        return GetValue(MouseOverFirstColorProperty) as SolidColorBrush;
        //    }
        //    set
        //    {
        //        SetValue(MouseOverFirstColorProperty, value);
        //    }
        //}

        //public SolidColorBrush MouseOverSecondColor
        //{
        //    get
        //    {
        //        return GetValue(MouseOverSecondColorProperty) as SolidColorBrush;
        //    }
        //    set
        //    {
        //        SetValue(MouseOverSecondColorProperty, value);
        //    }
        //}


        public Viewbox Viewbox
        {
            get
            {

                return GetValue(ViewboxProperty) as Viewbox;
            }
            set
            {
                SetValue(ViewboxProperty, value);
            }
        }

        static ViewboxIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ViewboxIcon), new FrameworkPropertyMetadata(typeof(ContentControl)));
            ViewboxProperty = DependencyProperty.Register("Viewbox", typeof(Viewbox), typeof(ViewboxIcon),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            //FirstColorProperty = DependencyProperty.Register("FirstColor", typeof(SolidColorBrush), typeof(ViewboxIcon),
            //    new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            //SecondColorProperty = DependencyProperty.Register("SecondColor", typeof(SolidColorBrush), typeof(ViewboxIcon),
            //    new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            //MouseOverFirstColorProperty = DependencyProperty.Register("MouseOverFirstColor", typeof(SolidColorBrush), typeof(ViewboxIcon),
            //    new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            //MouseOverSecondColorProperty = DependencyProperty.Register("MouseOverSecondColor", typeof(SolidColorBrush), typeof(ViewboxIcon),
            //    new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            SchemaManager.AddResource("pack://application:,,,/Ovotan.Windows.Controls;component/Resources/ViewboxButtonResource.xaml", "");
        }

        //protected override void OnInitialized(EventArgs e)
        //{
        //    base.OnInitialized(e);
        //    Content = Viewbox;
        //}

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var firstColor = Viewbox.Resources["first-color"] as SolidColorBrush;
            var secondColor = Viewbox.Resources["second-color"] as SolidColorBrush;
            if (firstColor != null && FirstColor != null)
            {
                FirstColor = new SolidColorBrush(Color.FromScRgb((float)firstColor.Opacity, FirstColor.Color.ScR, FirstColor.Color.ScG, FirstColor.Color.ScB));
                Viewbox.Resources["first-color"] = FirstColor;
                if (MouseOverFirstColor != null)
                {
                    MouseOverFirstColor = new SolidColorBrush(Color.FromScRgb((float)firstColor.Opacity, MouseOverFirstColor.Color.ScR, MouseOverFirstColor.Color.ScG, MouseOverFirstColor.Color.ScB));
                }
            }
            if (secondColor != null && SecondColor != null)
            {
                SecondColor = new SolidColorBrush(Color.FromScRgb((float)secondColor.Opacity, SecondColor.Color.ScR, SecondColor.Color.ScG, SecondColor.Color.ScB));
                Viewbox.Resources["second-color"] = SecondColor;
                if (MouseOverSecondColor != null)
                {
                    MouseOverSecondColor = new SolidColorBrush(Color.FromScRgb((float)secondColor.Opacity, MouseOverSecondColor.Color.ScR, MouseOverSecondColor.Color.ScG, MouseOverSecondColor.Color.ScB));
                }
            }
            MouseEnter += (s, a) =>
            {
                if (MouseOverFirstColor != null && firstColor != null)
                {
                    Viewbox.Resources["first-color"] = MouseOverFirstColor;
                }
                if (MouseOverSecondColor != null && secondColor != null)
                {
                    Viewbox.Resources["second-color"] = MouseOverSecondColor;
                }
            };
            MouseLeave += (s, a) =>
            {
                if (FirstColor != null && firstColor != null)
                {
                    Viewbox.Resources["first-color"] = FirstColor;
                }
                if (SecondColor != null && secondColor != null)
                {
                    Viewbox.Resources["second-color"] = SecondColor;
                }
            };
            Content = Viewbox;
            Viewbox.Width = Width;
            Viewbox.Height = Height;
        }
    }
}
