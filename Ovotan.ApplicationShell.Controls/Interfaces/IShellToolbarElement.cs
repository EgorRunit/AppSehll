using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Ovotan.ApplicationShell.Controls.Interfaces
{
    public enum ShellToolbarElementType
    {
        Button,
        Combobox
    }

    public interface IShellToolbarElement
    {
        string Text { get; set; }
            
        ShellToolbarElementType Type { get; set; }

        ICommand Command { get; set; }

    }

    public enum ShellToolbarElementAvtionType
    {
        Action,
        GroupFolder
    }
}
