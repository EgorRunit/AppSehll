using System.Windows;
using System.Windows.Controls;

namespace Ovotan.Windows.Controls.EndPointManagement
{
    public class TreeIconStyleSelector : DataTemplateSelector
    {
        public DataTemplate Table { get; set; }
        public DataTemplate Function { get; set; }
        public DataTemplate Database { get; set; }
        public DataTemplate Databases { get; set; }
        public DataTemplate Schemas { get; set; }
        public DataTemplate Schema { get; set; }
        public DataTemplate Tables { get; set; }
        public DataTemplate Sequences { get; set; }
        public DataTemplate Sequence { get; set; }
        public DataTemplate ServerGroup { get; set; }
        public DataTemplate ConnectorOffline { get; set; }
        public DataTemplate Folder { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            //var node = ((container as ContentPresenter).Content as ObjectBrowserNode);
            //if (node != null)
            //{
            //    switch (node.NodeType)
            //    {
            //        //case TreeNodeType.ServerGroup:
            //        //	return ServerGroup;
            //        case TreeNodeType.ConnectorOffline:
            //            return ConnectorOffline;
            //        //case TreeNodeType.Databases:
            //        //	return Databases;
            //        case TreeNodeType.Database:
            //            return Database;
            //        //case TreeNodeType.Schemas:
            //        //	return Schemas;
            //        case TreeNodeType.Schema:
            //            return Schema;
            //        //case TreeNodeType.Tables:
            //        //	return Tables;
            //        case TreeNodeType.Table:
            //            return Table;
            //        //case TreeNodeType.Sequences:
            //        //	return Sequences;
            //        case TreeNodeType.Sequence:
            //            return Sequence;
            //        case TreeNodeType.Function:
            //            return Function;
            //    }
            //}
            return Folder;
        }
    }
}
