using AppShell.Controls.UI;

namespace AppShell.Controls
{
    /// <summary>
    /// Перичесление доступных сообщений для DockingManager
    /// </summary>
    public enum DockingManagerMessageType
    {
        //Была приклеплена новая панель. В качестве аргумента события передается PanelAttachedArgs.
        PanelAttached,
        //Содержимое панели палучило фокус.
        PanelGotFocus,

    }

    /// <summary>
    /// Класс предоставляет аргументы для события DockingManagerMessageType.PanelAttached
    /// </summary>
    public class DockPanelAttachedArgs
    {
        public DockPanel DockPanel { get; set; }
        public DockPanelAttachedType AttachedType { get; set; }
    }
}
