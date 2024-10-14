using AppShell.Controls.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShell.Controls
{
    public class SnapPanelService : ISnapPanelService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="messageQueue"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        /// <exception cref="SnapPanelCreateException"></exception>
        public ISnapPanel Create(SnapPanelType type, ISnapManagerMessageQueue messageQueue, SnapPanelChild parent)
        {
            var snapPanel = new SnapPanel(type, messageQueue, parent);
            snapPanel.FirstChild = new SnapPanelChild(snapPanel, messageQueue);
            if (type != SnapPanelType.Default)
            {
                if (snapPanel.Parent == null)
                {
                    throw new SnapPanelCreateException();
                }
                snapPanel.FirstChild = new SnapPanelChild(snapPanel, messageQueue) { Type = SnapChildType.Content };
                snapPanel.SecondChild = new SnapPanelChild(snapPanel, messageQueue) { Type = SnapChildType.Content };
                switch (type)
                {
                    case SnapPanelType.Top:
                    case SnapPanelType.Left:
                        snapPanel.SecondChild.SnapSize = SnapSize.Stratch;
                        snapPanel.SecondChild.Type = parent.Type;
                        snapPanel.FirstChild.SnapSize = SnapSize.Percent;
                        snapPanel.FirstChild.Type = SnapChildType.Content;
                        break;
                    case SnapPanelType.Bottom:
                    case SnapPanelType.Right:
                        snapPanel.FirstChild.SnapSize = SnapSize.Stratch;
                        snapPanel.FirstChild.Type = parent.Type;
                        snapPanel.SecondChild.SnapSize = SnapSize.Percent;
                        snapPanel.SecondChild.Type = SnapChildType.Content;
                        break;
                }
            }
            return snapPanel;
        }
    }
}
