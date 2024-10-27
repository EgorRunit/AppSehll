using Ovotan.Windows.Controls.EndPointManagement.Enums;

namespace Ovotan.Shell.RabbitMQ.Controls.Configurations
{
    /// <summary>
    /// Класс описывает конфигурацию узла дерева.
    /// </summary>
    public class TreeItemConfiguration
    {
        /// <summary>
        /// get,set - Название узла.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Пользовательские данные узла.
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        /// get,set - Список дочерних узлов
        /// </summary>
        public List<TreeItemConfiguration> Childen { get; set; }

        /// <summary>
        /// get,set - Разрешена ли для узла отложенная загрузка
        /// </summary>
        public bool AllowLazyLoading { get; set; }

        /// <summary>
        /// get,set - Тип узла.
        /// </summary>
        public TreeItemType Type {get;set;}

        /// <summary>
        /// Конструктор.
        /// </summary>
        public TreeItemConfiguration()
        {
            Childen = new List<TreeItemConfiguration>();
        }
    }
}
