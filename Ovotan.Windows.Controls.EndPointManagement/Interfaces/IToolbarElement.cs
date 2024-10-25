using System.Windows.Input;

namespace Ovotan.Windows.Controls.EndPointManagements.Interfaces
{
    public enum ToolbarElementType
    {
        Button,
        Combobox
    }

    public interface IToolbarElement
    {
        string Text { get; set; }
            
        ToolbarElementType Type { get; set; }

        ICommand Command { get; set; }

    }

    public enum lToolbarElementActionType
    {
        Action,
        GroupFolder
    }
}
