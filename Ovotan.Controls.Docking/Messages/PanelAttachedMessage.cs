using Ovotan.Controls.Docking.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ovotan.Controls.Docking.Messages
{
    public class PanelAttachedMessage
    {
        public PanelAttachedType Type { get; set; }
        public FrameworkElement WindowContent { get; set; }
    }
}
