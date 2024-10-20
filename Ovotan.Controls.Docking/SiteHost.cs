using Ovotan.Controls.Docking.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace Ovotan.Controls.Docking
{
    /// <summary>
    /// Контрол для отображения открытых документов.
    /// </summary>
    public class SiteHost : ContentControl, ISiteHost
    {
        //Экземпляр очереди сообщений элметов докинга.
        IDockingMessageQueue _dockingMessageQueue;

        static SiteHost()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SiteHost), new FrameworkPropertyMetadata(typeof(ContentControl)));
        }

        public SiteHost(IDockingMessageQueue dockingMessageQueue)
        {
            _dockingMessageQueue = dockingMessageQueue;
        }
    }
}
