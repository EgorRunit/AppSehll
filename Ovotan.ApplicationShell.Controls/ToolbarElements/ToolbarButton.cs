using System.Windows;

namespace Ovotan.ApplicationShell.Controls.ToolbarElements
{
    public class ToolbarButton : ToolbarElementBase
    {
        static ToolbarButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToolbarButton), new FrameworkPropertyMetadata(typeof(ToolbarButton)));
        }
    }
}
