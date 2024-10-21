using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ovotan.ApplicationShell.Controls.Interfaces
{
    public enum ShellToolbarElementType
    {
        Button,
        Combobox
    }

    public interface IShellToolbarElement
    {
        string Text { get; }
            
        ShellToolbarElementType Type { get; }

        Action Callback { get; }

    }

    public class ShellToolbarElement : IShellToolbarElement
    {
        public string Text => "+";

        public ShellToolbarElementType Type { get; private set;}

        public Action Callback  { get; private set; }

        public ShellToolbarElement(ShellToolbarElementType type, Action callback)
        {
            Type = type;
            Callback = callback;
        }
    }

}
