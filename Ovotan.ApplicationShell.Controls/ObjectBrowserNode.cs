using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Ovotan.ApplicationShell.Controls
{
    public class ObjectBrowserNode : TreeViewItem
    {
        static ObjectBrowserNode()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ObjectBrowserNode), new FrameworkPropertyMetadata(typeof(TreeViewItem)));
        }
    }
}
