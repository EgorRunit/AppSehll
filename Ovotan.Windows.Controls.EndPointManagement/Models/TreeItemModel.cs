using Ovotan.Windows.Controls.EndPointManagement.Enums;

namespace Ovotan.ApplicationShell.Controls.Models
{
    public class TreeItemModel
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
        public TreeItemType Type { get; set; }

        /// <summary>
        /// get,set - Пользовательские данные узла.
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        /// get,set - Разрешена ли для узла отложенная загрузка
        /// </summary>
        public bool AllowLazyLoading { get; set; }
    }
}
