using Ovotan.ApplicationShell.Controls.Configurations;

namespace Ovotan.ApplicationShell.Controls.Enums
{
    public interface IEndPointObjectBrowserTreeItem
    {
        EndPointObjectBrowserTreeItemType Type { get; set; }

        /// <summary>
        /// Пользовательские данные узла.
        /// </summary>
        object Data { get; set; }

        /// <summary>
        /// Поддерживает ли узел ленивую загрузку дочерних узлов.
        /// </summary>
        bool IsLazyLoading { get; set; }

    }
}
