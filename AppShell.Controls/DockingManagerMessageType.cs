using AppShell.Controls.UI;

namespace AppShell.Controls
{
    /// <summary>
    /// Перичесление доступных сообщений для DockingManager
    /// </summary>
    public enum DockingManagerMessageType
    {
        /// <summary>
        /// Была приклеплена новая панель.
        /// В качестве аргумента события передается PanelAttachedArgs.
        /// </summary>
        PanelAttached,
        /// <summary>
        /// Панель была закрыта.
        /// В качестве аргумента события передается DockPanelAttachedType.
        /// </summary>
        PanelClosed,
        /// <summary>
        /// Содержимое панели палучило фокус.
        /// В качестве аргумента события передается DockPanelAttachedType.
        /// </summary>
        PanelGotFocus,

    }

    /// <summary>
    /// Класс предоставляет аргументы для события DockingManagerMessageType.PanelAttached
    /// </summary>
    public class DockPanelAttachedArgs
    {
        /// <summary>
        /// Экзепляр панели в которую (вставили\прикрепили) новую панель.
        /// </summary>
        public DockPanel DockPanel { get; set; }
        /// <summary>
        /// Место вставки.
        /// </summary>
        public DockPanelAttachedType AttachedType { get; set; }
    }
}
