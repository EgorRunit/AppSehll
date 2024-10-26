using System.Windows.Controls;

namespace Ovotan.Windows.Controls.Docking.Interfaces
{
    /// <summary>
    /// Интерфейс описывает контейнер для панеои.
    /// </summary>
    public interface IDockPanelContainer
    {
        UIElementCollection Children { get; }
    }
}
