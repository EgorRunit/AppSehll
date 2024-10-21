using Ovotan.ApplicationShell.Controls.Interfaces;
using Ovotan.Controls.Docking.Enums;
using Ovotan.Controls.Docking.Interfaces;
using Ovotan.Controls.Docking.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Ovotan.ApplicationShell.Controls
{
    public class ShellManagement
    {
        IDockingMessageQueue _dockingMessageQueue;
        Dictionary<Type, IShell> _shells;

        public ShellManagement(IDockingMessageQueue dockingMessageQueue) 
        {
            _shells = new Dictionary<Type, IShell>();
            _dockingMessageQueue = dockingMessageQueue;
        }

        public void StartShell(Type shellType)
        {
            IShell shell = null;
            if (_shells.ContainsKey(shellType))
            {
                 shell = _shells [shellType];
            }
            else
            {
                shell = Activator.CreateInstance(shellType) as IShell;
            }
            _dockingMessageQueue.Publish(DockingMessageType.ShowDockPanelWindow, shell.ObjectBrowser);

        }

    }
}
