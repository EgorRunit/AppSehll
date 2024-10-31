//using Ovotan.Windows.Controls.Docking.Enums;
//using Ovotan.Windows.Controls.Docking;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Media;

//namespace Ovotan.Windows.Controls.EndPointManagement
//{
//    /// <summary>
//    /// Пиричесление известных шаблонов иконок для ViewboxButton.
//    /// </summary>
//    public enum ViewBoxButtonType
//    {
//        /// <summary>
//        /// Иконка отсутсвует.
//        /// </summary>
//        None,
//        /// <summary>
//        /// Иконка соединения.
//        /// </summary>
//        Connection,
//        /// <summary>
//        /// Иконка создания нового соединения.
//        /// </summary>
//        NewConnection
//    }

//    public class ViewboxButton : ContentControl
//    {
//        /// <summary>
//        /// Зависимое свойство. Цвет заливки в о бычном состоянии.
//        /// </summary>
//        public static readonly DependencyProperty Brush1Property;
//        /// <summary>
//        /// Зависимое свойство. Цвет заливки в о бычном состоянии.
//        /// </summary>
//        public static readonly DependencyProperty Brush2Property;
//        /// <summary>
//        /// Зависимое свойство. Цвет заливки в о бычном состоянии.
//        /// </summary>
//        public static readonly DependencyProperty Brush3Property;

//        public static readonly DependencyProperty ViewboxProperty;

//        public ViewBoxButtonType ViewboxType { get; set; }

//        public Viewbox Viewbox
//        {
//            get
//            {

//                return GetValue(ViewboxProperty) as Viewbox;
//            }
//            set
//            {
//                SetValue(ViewboxProperty, value);
//            }
//        }


//        /// <summary>
//        /// Get,Set - Цвет заливки в о бычном состоянии.
//        /// </summary>
//        public SolidColorBrush Brush1
//        {
//            get
//            {

//                return GetValue(Brush1Property) as SolidColorBrush;
//            }
//            set
//            {
//                SetValue(Brush1Property, value);
//            }
//        }

//        /// <summary>
//        /// Get,Set - Цвет заливки в о бычном состоянии.
//        /// </summary>
//        public SolidColorBrush Brush2
//        {
//            get
//            {

//                return GetValue(Brush2Property) as SolidColorBrush;
//            }
//            set
//            {
//                SetValue(Brush2Property, value);
//            }
//        }

//        /// <summary>
//        /// Get,Set - Цвет заливки в о бычном состоянии.
//        /// </summary>
//        public SolidColorBrush Brush3
//        {
//            get
//            {

//                return GetValue(Brush3Property) as SolidColorBrush;
//            }
//            set
//            {
//                SetValue(Brush3Property, value);
//            }
//        }

//       static ViewboxButton()
//        {
//            DefaultStyleKeyProperty.OverrideMetadata(typeof(ViewboxButton), new FrameworkPropertyMetadata(typeof(ContentControl)));

//            Brush1Property = DependencyProperty.Register("Brush1", typeof(SolidColorBrush), typeof(ViewboxButton),
//                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
//            Brush2Property = DependencyProperty.Register("Brush2", typeof(SolidColorBrush), typeof(ViewboxButton),
//                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
//            Brush3Property = DependencyProperty.Register("Brush3", typeof(SolidColorBrush), typeof(ViewboxButton),
//                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));

//            ViewboxProperty = DependencyProperty.Register("ViewboxProperty", typeof(Viewbox), typeof(ViewboxButton),
//                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
//        }


//        public override void OnApplyTemplate()
//        {
            
//            base.OnApplyTemplate();
//            var viewBox = Template.FindName("MainViewBox", this) as ContentControl;

//            if (ViewboxType != ViewBoxButtonType.None)
//            {
//                switch (ViewboxType)
//                {
//                    case ViewBoxButtonType.Connection:
//                        Viewbox = Template.FindName("OVBT_Connection",this) as Viewbox;
//                        break;
//                    case ViewBoxButtonType.NewConnection:
//                        Viewbox = Template.FindName("OVBT_NewConnection", this) as Viewbox;
//                        break;
//                }
//            }
//            viewBox.Content = Viewbox;
//            Viewbox.SetValue(DataContextProperty, this);
//        }

//    }
//}
