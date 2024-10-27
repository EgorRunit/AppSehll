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
                object tag = null;
                if(node.Tag != null)
                {
                    var tmp = node.Tag.ToString().Split(":", 2);
                    if(!(_types.ContainsKey(tmp[0])))
                    {
                        throw new Exception("wwww");
                    }
                    var type = _types[tmp[0]];
                    tag = JsonSerializer.Deserialize(tmp[1], type);
                }
                var item = new TreeItem()
                {
                    Header = node.Header,
                    Tag = tag,
                    AllowLazyLoading = node.AllowLazyLoading,
                    Type = node.Type
                };
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
                if (node.Type == TreeItemType.Configuration || node.Type == TreeItemType.BaseHttpConfiguration)
                {
                    var children = _getConfigurationNodes(node.Items);

                    var data = string.Empty;
                    if(node.Tag != null)
                    {
                        data = node.Tag.GetType().FullName + ":";
                        data += JsonSerializer.Serialize(node.Tag);
                        node.Tag = data;
                    }

                    nodes.Add(new TreeItemConfiguration()
                    {
                        Header = node.Header.ToString(),
                        Tag = node.Tag,
                        AllowLazyLoading = node.AllowLazyLoading,
                        Childen = children.Count > 0 ? children : null,
                        Type = node.Type,
                    });
                    
                }
            }
            return nodes;
        }
    }
}
