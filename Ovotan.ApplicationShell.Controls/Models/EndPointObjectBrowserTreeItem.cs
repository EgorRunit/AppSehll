using Ovotan.ApplicationShell.Controls.Configurations;

namespace Ovotan.ApplicationShell.Controls.Models
{
    public class EndPointObjectBrowserTreeViewChidlTreeItem
    {
        /// <summary>
        /// get,set - Название узла.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// get,set - Поддерживает ли узел ленивую загрузку дочерних узлов.
        /// </summary>
        public bool IsLazyLoading { get; set; }

        /// <summary>
        /// get,set - Тип узла.
        /// </summary>
        public EndPointObjectBrowserTreeItemType Type { get; set; }

        /// <summary>
        /// get,set - Пользовательские данные узла.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// get,set - Разрешена ли для узла отложенная загрузка
        /// </summary>
        public bool AllowLazyLoading { get; set; }
    }
}
