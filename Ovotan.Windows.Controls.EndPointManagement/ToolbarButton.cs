using System.Windows;

namespace Ovotan.Windows.Controls.EndPointManagement
{
    public class ToolbarButton : ToolbarElementBase
    {
        static ToolbarButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToolbarButton), new FrameworkPropertyMetadata(typeof(ToolbarButton)));
        }
    }
}
