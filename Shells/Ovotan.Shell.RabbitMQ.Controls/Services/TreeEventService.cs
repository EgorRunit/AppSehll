using Ovotan.Shell.RabbitMQ.Api;
using Ovotan.Shell.RabbitMQ.Controls.Docuemnts;
using Ovotan.Shell.RabbitMQ.Controls.Enums;
using Ovotan.Windows.Controls;
using Ovotan.Windows.Controls.Docking.Interfaces;
using Ovotan.Windows.Controls.EndPointManagement;
using Ovotan.Windows.Controls.EndPointManagement.Interfaces;
using System.Windows.Controls;

namespace Ovotan.Shell.RabbitMQ.Controls.Services
{
    internal class TreeEventService : ITreeEventService
    {
        TreeView _treeView;
        ISiteHost _siteHost;
        Dictionary<TreeItemActionType, (Guid id, Func<RabbitMQApiHttpClient, ISiteHostDocument> action)> _tmp;

        internal TreeEventService(ISiteHost siteHost, TreeView treeView) 
        { 
            _siteHost = siteHost;
            _treeView = treeView;

            _tmp = new Dictionary<TreeItemActionType, (Guid, Func<RabbitMQApiHttpClient, ISiteHostDocument>)>();
            _tmp.Add(TreeItemActionType.Streams, new ( RabbitMQDocumentTDs.Streams, (x) => { return null; }));
            _tmp.Add(TreeItemActionType.Queues, new (RabbitMQDocumentTDs.Queues, (x) => new QueueListDocument(x)));
            _tmp.Add(TreeItemActionType.Exchanges, new(RabbitMQDocumentTDs.Exchanges, (x) => { return null; }));
            _tmp.Add(TreeItemActionType.Connections, new ( RabbitMQDocumentTDs.Connections, (x) => new ConnectionListDocument(x)));
            _tmp.Add(TreeItemActionType.Channels, new (RabbitMQDocumentTDs.Channels, (x) =>  new ChannelListDocument(x)));
        }

        void ITreeEventService.SelectedNode(TreeItem treeItem) 
        {
            if (treeItem.Tag is TreeItemActionType)
            {
                var type = (TreeItemActionType)treeItem.Tag;
                var tuple = _tmp[type];
                if (!_siteHost.TryActivate(tuple.id))
                {
                    var managerSettings = treeItem.FindLogicalParentTag<RabbitMQApiHttpClient>().FirstOrDefault();
                    var document = tuple.action(managerSettings);
                    if (document != null)
                    {
                        _siteHost.AddDocument(document);
                    }
                }
            }
        }

    }

   

    public static class RabbitMQDocumentTDs
    {
        public static Guid Connections { get; } = new Guid("{7A3177A4-BF6D-4BD7-A32A-56E7B70738EC}");
        public static Guid Queues { get; } = new Guid("{63B8C185-FBCC-44B0-B6F9-038CCD8B60D4}");
        public static Guid Channels { get; } = new Guid("{9830E059-2076-4778-9BBB-D66570CE3584}");
        public static Guid Streams { get; } = new Guid("{3882E487-DD54-4DD7-9DE7-E00051DEE097}");
        public static Guid Exchanges { get; } = new Guid("{3380229B-0AEA-4C8B-B823-30391FDD617E}");
    }

}
