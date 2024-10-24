using Ovotan.Controls.Docking.Interfaces;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ovotan.Controls.Docking
{
    /// <summary>
    /// Контрол для отображения открытых документов.
    /// </summary>
    public class SiteHost : ContentControl, ISiteHost
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
        }

        public void AddDocument(ISiteHostDocument document)
        {
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _tabControl = Template.FindName("TabControl", this) as TabControl;
        }
    }
}
