using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xml.Linq;

namespace Ovotan.Windows.Controls.Docking
{
    [ContentProperty("Elements")]
    public class SiteHostTabControl : ContentControl
    {
        public static DependencyProperty ElementsProperty;

        public ObservableCollection<FrameworkElement> Elements
        {
            get
            {
                return GetValue(ElementsProperty) as ObservableCollection<FrameworkElement>;
            }
            set
            {
                SetValue(ElementsProperty, value);
            }
        }


        Canvas _canvas;
        static SiteHostTabControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SiteHostTabControl), new FrameworkPropertyMetadata(typeof(SiteHostTabControl)));
            ElementsProperty = DependencyProperty.Register("Elements", typeof(ObservableCollection<FrameworkElement>), typeof(SiteHostTabControl),
                new FrameworkPropertyMetadata(new ObservableCollection<FrameworkElement>(), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _canvas = Template.FindName("Canvas", this) as Canvas;
            foreach (var element in Elements)
            {
                _canvas.Children.Add(element);
            }
            InvalidateMeasure();

        }

        protected override Size MeasureOverride(Size constraint)
        {
            var r = base.MeasureOverride(constraint);

            var left = 0.0;
            var top = 0.0;
            var actualWidth = constraint.Width;

            foreach (var element in Elements)
            {
                element.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                var height = element.DesiredSize.Height;
                var width = element.DesiredSize.Width;
                if (left + width > actualWidth)
                {
                    element.Visibility = Visibility.Hidden;
                }
                else
                {
                    element.Visibility = Visibility.Visible;
                    element.SetValue(Canvas.LeftProperty, left);
                    element.SetValue(Canvas.TopProperty, top);
                }

                left += width;
                //_canvas.Children.Add(element);

            }
            //foreach (var element in Elements)
            //{
            //    element.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            //    var height = element.DesiredSize.Height;
            //    var width = element.DesiredSize.Width;
            //    if (left + width > actualWidth)
            //    {
            //        left = 0;
            //        top += height;
            //    }
            //    element.SetValue(Canvas.LeftProperty, left);
            //    element.SetValue(Canvas.TopProperty, top);

            //    left += width;
            //    //_canvas.Children.Add(element);

            //}
            return r;
        }
    }
}
