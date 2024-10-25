using Ovotan.Windows.Controls.EndPointManagements.Interfaces;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ovotan.Windows.Controls.EndPointManagement
{
    public abstract class ToolbarElementBase : ContentControl, IToolbarElement
    {
        public string Text { get; set; }
        public ToolbarElementType Type { get; set; }
        public ICommand Command { get; set; }
    }
}
