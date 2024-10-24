using Ovotan.Controls.Docking.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace Ovotan.ApplicationShell.Controls
{
    public class EndPoint : ContentControl
    {
        protected IDockingMessageQueue dockingMessageQueue;
        protected ToolBar toolBar;
        protected TreeView treeView;

        static EndPoint()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EndPoint), new FrameworkPropertyMetadata(typeof(EndPoint)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            toolBar = Template.FindName("Toolbar", this) as ToolBar;
            treeView = Template.FindName("TreeView", this) as TreeView;

        }

        public virtual void Start(IDockingMessageQueue dockingMessageQueue)
        {
            this.dockingMessageQueue = dockingMessageQueue;
        }
    }
}
