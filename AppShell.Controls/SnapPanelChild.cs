using AppShell.Controls.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppShell.Controls
{
    public class SnapPanelChild : ISnapPanelChild
    {
        ISnapManagerMessageQueue _messageQueue;

        public ISnapPanel Parent { get; set; }
        public ISnapPanel Child { get; set; }
        public SnapSize SnapSize { get; set; }
        public SnapChildType Type { get; set; }
        public List<ISnapChildControl> Controls { get; set; }

        internal SnapPanelChild(ISnapPanel parent, ISnapManagerMessageQueue messageQueue)
        {
            if(parent == null)
            {
                throw new ArgumentNullException("parent");
            }
            if(messageQueue == null)
            {
                throw new ArgumentNullException("messageQueue");
            }
            _messageQueue = messageQueue;
            Controls = new List<ISnapChildControl>();
            Type = SnapChildType.Base;
            SnapSize = SnapSize.Stratch;
            Parent = parent;
        }

        public void AddControl(ISnapChildControl control)
        {
            var oldControl = Controls.SingleOrDefault(x => x == control);
            if(oldControl != null)
            {
                throw new ArgumentException("", "");
            }
            Controls.Add(control);
        }

        public void AddPanel(SnapPanelType snapPanelType, ISnapChildControl snapControl)
        {
            var _snapPanelService = new SnapPanelService();
            if (Type == SnapChildType.SnapPanel)
            {
                throw new SnapPanelChildReInsertionException();
            }
            
            Child = _snapPanelService.Create(snapPanelType, _messageQueue , this);
            Type = SnapChildType.SnapPanel;
            var args = new SnapPanelChangedArgs() { NewSnapPanel = Child, ChangedSnapPanel = this.Parent };

            _messageQueue.Publish("SpanPanelChanged", args);
        }
    }

    public class SnapPanelChangedArgs
    {
        public ISnapPanel ChangedSnapPanel;
        public ISnapPanel NewSnapPanel;
        
    }
}
