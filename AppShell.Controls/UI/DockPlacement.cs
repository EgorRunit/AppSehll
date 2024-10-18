using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppShell.Controls.UI
{
    public class DockPlacement : Window
    {
        public DockPlacement() 
        {
            WindowStyle = WindowStyle.ToolWindow;
            ResizeMode = ResizeMode.NoResize;
        }
    }
}
