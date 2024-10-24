using Ovotan.Controls.Docking.Interfaces;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ovotan.Controls.Docking
{
    /// <summary>
    /// Контрол для отображения открытых документов.
    /// </summary>
    public class SiteHost : ContentControl
    {
        //Экземпляр очереди сообщений элметов докинга.
        IDockingMessageQueue _dockingMessageQueue;
        TabControl _tabControl;

        static SiteHost()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SiteHost), new FrameworkPropertyMetadata(typeof(SiteHost)));
        }

        public SiteHost(IDockingMessageQueue dockingMessageQueue)
        {
            _dockingMessageQueue = dockingMessageQueue;
            _tabControl = new TabControl();
            _tabControl.Items.Add(new TabItem() { Header = "234534534" });
            Background = new SolidColorBrush(Colors.Red);
            _tabControl.Background = new SolidColorBrush(Colors.Red);
            //Content = new TextBox();
            //AddChild(_tabControl);
//            Template = _dockingMessageQueue;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var eertre = Template.FindName("RRRR", this);
            var ss = Template.FindName("TabControl", this);
        }
    }
}
