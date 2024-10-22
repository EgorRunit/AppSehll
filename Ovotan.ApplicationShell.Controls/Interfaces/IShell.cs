using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Linq;
using Ovotan.Controls.Docking.Interfaces;

namespace Ovotan.ApplicationShell.Controls.Interfaces
{

    public interface IShell
    {
        IEnumerable<IShellToolbarElement> ObjectBrowserToolbarElements { get; }

        ShellObjectBrowser ObjectBrowser { get; }


        void Start(IDockingMessageQueue dockingMessageQueue);
    }
}
