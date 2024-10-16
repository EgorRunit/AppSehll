using System;

namespace AppShell.Controls
{
    public interface IDockingManagerMessageQueue
    {
        void Publish(DockingManagerMessageType messageType, object args);
        void Register(DockingManagerMessageType messageType, Action<object> args);
    }
}
