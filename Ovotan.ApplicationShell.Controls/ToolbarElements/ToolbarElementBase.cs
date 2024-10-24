using Ovotan.ApplicationShell.Controls.Interfaces;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ovotan.ApplicationShell.Controls.ToolbarElements
{
    public abstract class ToolbarElementBase : ContentControl, IShellToolbarElement
    {
        public string Text { get; set; }
        public ShellToolbarElementType Type { get; set; }
        public Action Action { get; set; }
        public ICommand Command { get; set; }
    }
}
