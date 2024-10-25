using System.Windows.Controls;
using System.Windows;
using Ovotan.Shell.RabbitMQ.Controls.Configurations;
using Ovotan.ApplicationShell.Controls.Configurations;
using System.Text.Json;
using System.Linq;

namespace Ovotan.ApplicationShell.Controls
{
    public class EndPointObjectTree : TreeView
    {
        Dictionary<string, Type> _types;

        static EndPointObjectTree()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EndPointObjectTree), new FrameworkPropertyMetadata(typeof(TreeView)));
        }

        public EndPointObjectTree()
        {
            _types = new Dictionary<string, Type>();
        }

        public void AddDataType(Type dataType)
        {
            _types.Add(dataType.FullName, dataType);
        }

        public List<EndPointObjectBrowserTreeItemConfiguration> GetConfigurationNodes()
        {
            var result = new List<EndPointObjectBrowserTreeItemConfiguration>();
            return _getConfigurationNodes(Items);
        }

        public void LoadCoonfigurationNodes(List<EndPointObjectBrowserTreeItemConfiguration> nodes)
        {
            _loadCoonfigurationNodes(nodes, Items);
        }

        void _loadCoonfigurationNodes(List<EndPointObjectBrowserTreeItemConfiguration> nodes, ItemCollection itemCollection)
        {
            foreach (var node in nodes)
            {
                object data = null;
                if(node.Data != null)
                {
                    var tmp = node.Data.ToString().Split(":", 2);
                    if(!(_types.ContainsKey(tmp[0])))
                    {
                        throw new Exception("wwww");
                    }
                    var type = _types[tmp[0]];
                    data = JsonSerializer.Deserialize(tmp[1], type);
                }
                var item = new EndPointObjectBrowserTreeItem()
                {
                    Type = EndPointObjectBrowserTreeItemType.Configuration,
                    Header = node.Header,
                    Data = data
                };
                itemCollection.Add(item);
                if(node.Childen != null)
                {
                    _loadCoonfigurationNodes(node.Childen, item.Items);
                }
            }
        }

        List<EndPointObjectBrowserTreeItemConfiguration> _getConfigurationNodes(ItemCollection itemCollection)
        {
            var nodes = new List<EndPointObjectBrowserTreeItemConfiguration>();

            foreach (var item in itemCollection)
            {
                var node = item as EndPointObjectBrowserTreeItem;
                if (node.Type == EndPointObjectBrowserTreeItemType.Configuration)
                {
                    var children = _getConfigurationNodes(node.Items);

                    var data = string.Empty;
                    if(node.Data != null)
                    {
                        data = node.Data.GetType().FullName + ":";
                        data += JsonSerializer.Serialize(node.Data);
                        node.Data = data;
                    }

                    nodes.Add(new EndPointObjectBrowserTreeItemConfiguration()
                    {
                        Header = node.Header.ToString(),
                        Data = node.Data,
                        Childen = children.Count > 0 ? children : null,
                    });
                    
                }
            }
            return nodes;
        }
    }
}
