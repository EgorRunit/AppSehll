using AppShell.Controls.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AppShell.Controls
{
    public class DockingManagerSetting : FrameworkElement
    {
        /// <summary>
        /// Цвет фона заголовка элемента DockGridContent.
        /// </summary>
        public static readonly DependencyProperty DockGridContentHeader_Background_Property;
        /// <summary>
        /// Цвет текста заголовка элемента DockGridContent.
        /// </summary>
        public static readonly DependencyProperty DockGridContentHeader_Foreground_Property;

        public static readonly DependencyProperty DockGridContentIcon_Normal_Foreground_Property;
        public static readonly DependencyProperty DockGridContentIcon_Hover_Foreground_Property;

        public SolidColorBrush DockGridContentIcon_Normal_Foreground
        {
            get
            {

                return GetValue(DockGridContentIcon_Normal_Foreground_Property) as SolidColorBrush;
            }
            set
            {
                SetValue(DockGridContentIcon_Normal_Foreground_Property, value);
            }
        }

        public SolidColorBrush DockGridContentIcon_Hover_Foreground
        {
            get
            {

                return GetValue(DockGridContentIcon_Hover_Foreground_Property) as SolidColorBrush;
            }
            set
            {
                SetValue(DockGridContentIcon_Hover_Foreground_Property, value);
            }
        }

        public SolidColorBrush DockGridContentHeader_Foreground
        {
            get
            {

                return GetValue(DockGridContentHeader_Foreground_Property) as SolidColorBrush;
            }
            set
            {
                SetValue(DockGridContentHeader_Foreground_Property, value);
            }
        }


        public SolidColorBrush DockGridContentHeader_Background
        {
            get
            {

                return GetValue(DockGridContentHeader_Background_Property) as SolidColorBrush;
            }
            set
            {
                SetValue(DockGridContentHeader_Background_Property, value);
            }
        }

        static DockingManagerSetting()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DockingManagerSetting), new FrameworkPropertyMetadata(typeof(DockingManagerSetting)));

            DockGridContentHeader_Background_Property = DependencyProperty.Register("DockGridContentHeader_Background", typeof(SolidColorBrush), typeof(DockingManagerSetting),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            DockGridContentHeader_Foreground_Property = DependencyProperty.Register("DockGridContentHeader_Foreground", typeof(SolidColorBrush), typeof(DockingManagerSetting),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            DockGridContentIcon_Normal_Foreground_Property = DependencyProperty.Register("DockGridContentIcon_Normal_Foreground", typeof(SolidColorBrush), typeof(DockingManagerSetting),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            DockGridContentIcon_Hover_Foreground_Property = DependencyProperty.Register("DockGridContentIcon_Hover_Foreground", typeof(SolidColorBrush), typeof(DockingManagerSetting),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));

        }

    }
}
