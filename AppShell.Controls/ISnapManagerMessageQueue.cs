namespace AppShell.Controls
{
    public interface ISnapManagerMessageQueue
    {
        void Publish(string messageName, object args);
        void Register(string messageName, RiseMessage consumer);
    }
}