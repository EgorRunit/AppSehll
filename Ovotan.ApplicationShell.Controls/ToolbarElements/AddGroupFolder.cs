using Ovotan.ApplicationShell.Controls.Interfaces;

namespace Ovotan.ApplicationShell.Controls.ToolbarElements
{
    public class AddGroupFolder : ToolbarElementBase
    {
        public AddGroupFolder() 
        {
            Text = "++";
            Type = ShellToolbarElementType.Button;
        }
    }
}
