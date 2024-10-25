using System.Windows.Controls;
using System.Windows;
using System.Text.Json;
using Ovotan.Windows.Controls.EndPointManagement.Enums;
using Ovotan.Shell.RabbitMQ.Controls.Configurations;

namespace Ovotan.Windows.Controls.EndPointManagement
{
    public class Tree : TreeView
    {
        Dictionary<string, Type> _types;

        static Tree()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Tree), new FrameworkPropertyMetadata(typeof(TreeView)));
        }

        public Tree()
        {
            _types = new Dictionary<string, Type>();
        }

        public void AddDataType(Type dataType)
        {
            _types.Add(dataType.FullName, dataType);
        }

        public List<TreeItemConfiguration> GetConfigurationNodes()
        {
            var result = new List<TreeItemConfiguration>();
            return _getConfigurationNodes(Items);
        }

        public void LoadCoonfigurationNodes(List<TreeItemConfiguration> nodes)
        {
            _loadCoonfigurationNodes(nodes, Items);
        }

        void _loadCoonfigurationNodes(List<TreeItemConfiguration> nodes, ItemCollection itemCollection)
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
                var item = new TreeItem()
                {
                    Header = node.Header,
                    Data = data,
                    AllowLazyLoading = node.AllowLazyLoading,
                    Type = TreeItemType.Configuration
                };
                item.IsLazyLoading = item.AllowLazyLoading;
                itemCollection.Add(item);
                if(node.Childen != null)
                {
                    _loadCoonfigurationNodes(node.Childen, item.Items);
                }
            }
        }

        List<TreeItemConfiguration> _getConfigurationNodes(ItemCollection itemCollection)
        {
            var nodes = new List<TreeItemConfiguration>();

            foreach (var item in itemCollection)
            {
                var node = item as TreeItem;
                if (node.Type == TreeItemType.Configuration)
                {
                    var children = _getConfigurationNodes(node.Items);

                    var data = string.Empty;
                    if(node.Data != null)
                    {
                        data = node.Data.GetType().FullName + ":";
                        data += JsonSerializer.Serialize(node.Data);
                        node.Data = data;
                    }

                    nodes.Add(new TreeItemConfiguration()
                    {
                        Header = node.Header.ToString(),
                        Data = node.Data,
                        AllowLazyLoading = node.AllowLazyLoading,
                        Childen = children.Count > 0 ? children : null,
                    });
                    
                }
            }
            return nodes;
        }
    }
}
