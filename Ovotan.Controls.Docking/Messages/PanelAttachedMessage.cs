using Ovotan.Controls.Docking.Enums;
using System.Windows;

namespace Ovotan.Controls.Docking.Messages
{
    public class PanelAttachedMessage
    {
        /// <summary>
        /// Ттип прилипания панели к хосту докинга.
        /// </summary>
        public PanelAttachedType Type { get; set; }
        /// <summary>
        /// Содержимое вставляемой панели.
        /// </summary>
        public FrameworkElement DockPanelContent { get; set; }
    }
}
