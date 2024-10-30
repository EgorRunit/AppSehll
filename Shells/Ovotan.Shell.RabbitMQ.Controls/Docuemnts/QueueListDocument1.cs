using Ovotan.Shell.RabbitMQ.Api;
using Ovotan.Shell.RabbitMQ.Controls.Services;
using Ovotan.Windows.Controls.EndPointManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Ovotan.Shell.RabbitMQ.Controls.Docuemnts
{
    public class QueueListDocument1 : SiteHostDocumentDataGrid
    {
        /// <summary>
        /// Экземпляр Http клиента для даступа к апи.
        /// </summary>
        protected RabbitMQApiHttpClient client;

        public QueueListDocument1()
        {
            //this.Style = Resources["SiteHostDocumentDataGrid"] as Style;
        }

        static QueueListDocument1()
        {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(QueueListDocument1), new FrameworkPropertyMetadata(typeof(QueueListDocument1)));
        }

        public QueueListDocument1(RabbitMQApiHttpClient client)
        {
            this.client = client;
            Header = "Rabbit - Список Очередей";
            IsStatic = true;
            ID = RabbitMQDocumentTDs.Queues;
        }
    }
}
