using Ovotan.Controls.Docking.Enums;
using Ovotan.Controls.Docking.Messages;
using System.Windows;

namespace Ovotan.Controls.Docking.Interfaces
{
    /// <summary>
    /// Интерфейс для сервиса управляющего структорой докинга.
    /// </summary>
    public interface IDockConstractureService
    {
        /// <summary>
        /// Разбить панель на две части.
        /// </summary>
        /// <param name="message">Сообщение с данными разбития панели</param>
        void SplitPanel(PanelSplittedMessage message);
        /// <summary>
        /// Удалить панель.
        /// </summary>
        /// <param name="panel"></param>
        void RemovePanel(DockPanel panel);

        void AttachPanel(PanelAttachedType type, DockingHost dockingHost, FrameworkElement dockPanelContent);
    }
}
