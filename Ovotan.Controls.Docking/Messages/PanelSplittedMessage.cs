using Ovotan.Controls.Docking.Enums;

namespace Ovotan.Controls.Docking.Messages
{
    /// <summary>
    /// Класс предоставляет аргументы для события DockingManagerMessageType.PanelSplitted
    /// </summary>
    public class PanelSplittedMessage
    {
        /// <summary>
        /// Экзепляр разделяемой панели.
        /// </summary>
        public DockPanel PanelSplitted { get; set; }
        /// <summary>
        /// Тип разделения панели.
        /// </summary>
        public PanelSplittedType SplitType { get; set; }
    }
}
