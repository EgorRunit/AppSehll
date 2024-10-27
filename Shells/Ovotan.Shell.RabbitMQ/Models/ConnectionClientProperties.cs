using System;
using System.Collections.Generic;
using System.Text;

namespace Ovotan.Shell.RabbitMQ.Models
{
    public  class ConnectionClientProperties
    {
        /// <summary>
        /// get,set - Клиантскаое название подключения.
        /// </summary>
        public string ConnectionName { get; set; }
        /// <summary>
        /// get,set - Правообладатель.
        /// </summary>
        public string Copyright { get; set; }
        /// <summary>
        /// get,set - Дополнительня информация.
        /// </summary>
        public string Information { get; set; }
        /// <summary>
        /// get,set - Платформа разработки.
        /// </summary>
        public string Platform { get; set; }
        /// <summary>
        /// get,set - Название продукта.
        /// </summary>
        public string Product { get; set; }
        /// <summary>
        /// get,set - Версия библиотеки использованной для создания подключения.
        /// </summary>
        public string Version { get; set; }
    }
}
