using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Ovotan.ApplicationShell.Controls
{
    public class ObjectBrowserStyleSelector : DataTemplateSelector
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

    public enum TreeNodeType
    {
        Root = 0,
        ServerGroup = 1,
        ConnectorOffline = 2,
        ConnectorOnline = 3,

        Databases = 100,
        Database = 101,

        Tables = 200,
        Table = 201,
        Columns = 202,
        Indexes = 203,
        Rules = 204,
        Triggers = 205,

        Views = 300,
        View = 301,

        Schemas = 400,
        Schema = 401,

        Functions = 500,
        Function = 501,

        StoredProcedures = 600,
        StoredProcedure = 601,

        Sequences = 700,
        Sequence = 701,


        Securities = 800,
        Users = 801,
        User = 802,
        Roles = 803,
        Role = 804,



        Languages = 900,



        Custom = 65000,
        Folder = 65001,
    }

}
