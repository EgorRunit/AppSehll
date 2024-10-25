namespace Ovotan.Shell.RabbitMQ.Controls.Configurations
{
    /// <summary>
    /// Класс описывает конфигурацию узла дерева.
    /// </summary>
    public class EndPointObjectBrowserTreeItemConfiguration
    {
        /// <summary>
        /// get,set - Название узла.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Пользовательские данные узла.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// get,set - Поддерживает ли узел ленивую загрузку дочерних узлов.
        /// </summary>
        public bool IsLazyLoading { get; set; }

        /// <summary>
        /// get,set - Список дочерних узлов
        /// </summary>
        public List<EndPointObjectBrowserTreeItemConfiguration> Childen { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        public EndPointObjectBrowserTreeItemConfiguration()
        {
            Childen = new List<EndPointObjectBrowserTreeItemConfiguration>();
        }

    }
}
