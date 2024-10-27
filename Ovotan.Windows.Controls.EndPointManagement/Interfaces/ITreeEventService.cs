using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovotan.Windows.Controls.EndPointManagement.Interfaces
{
    public interface ITreeEventService
    {
        void SelectedNode(TreeItem treeItem) { }
        void DoubleClick() { }
        void ShowContextMenu() { }
    }
}
