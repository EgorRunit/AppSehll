using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AppShell.Controls.UI
{
    public class HideShowButton : Button
    {
        public HideShowButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HideShowButton), new FrameworkPropertyMetadata(typeof(HideShowButton)));
        }
    }
}
