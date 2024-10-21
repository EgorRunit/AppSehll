using Ovotan.Controls.Docking.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovotan.Controls.Docking.Messages
{
    public class PanelShowWindow
    {
        public IDockPanel DockPanel { get; set; }
    }
}
