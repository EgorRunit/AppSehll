using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Linq;

namespace Ovotan.ApplicationShell.Controls.Interfaces
{

    public interface IShell
    {
        IEnumerable<IShellToolbarElement> ObjectBrowserToolbarElements { get; }

        ShellObjectBrowser ObjectBrowser { get; }
    }
}
