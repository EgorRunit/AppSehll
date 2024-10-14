using System;

namespace AppShell.Controls.Exceptions
{
    public class SnapPanelCreateException : Exception
    {
        public SnapPanelCreateException()
            : base("Нельзя создавать панель с типом отличным от Default, не указав владельца панели (SnapPanelChild)")
        { 
        }
    }
}
