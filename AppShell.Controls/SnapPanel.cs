namespace AppShell.Controls
{
    internal class SnapPanel : ISnapPanel
    {
        ISnapManagerMessageQueue _messageQueue;
        public ISnapPanelChild Parent { get; private set; }
        public ISnapPanelChild FirstChild { get; internal set; }
        public ISnapPanelChild SecondChild { get; internal set; }
        public SnapPanelType Type { get; private set; }

        internal SnapPanel(SnapPanelType type, ISnapManagerMessageQueue messageQueue, ISnapPanelChild parent)
        {
            _messageQueue = messageQueue;
            Type = type;
            Parent = parent;
        }
    }
}
