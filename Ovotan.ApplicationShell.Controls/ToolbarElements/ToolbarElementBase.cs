using Ovotan.ApplicationShell.Controls.Interfaces;

namespace Ovotan.ApplicationShell.Controls.ToolbarElements
{
    public class ToolbarElementBase : IShellToolbarElement
    {
        public string Text { get; set; }
        public ShellToolbarElementType Type { get; set; }
        public Action Action { get; set; }
    }
}
