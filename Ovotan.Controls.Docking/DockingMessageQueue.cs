using Ovotan.Controls.Docking.Enums;
using Ovotan.Controls.Docking.Interfaces;

namespace Ovotan.Controls.Docking
{
    /// <summary>
    /// Очередь сообщенимй для DockingManager
    /// </summary>
    public class DockingMessageQueue : IDockingMessageQueue
    {
        /// <summary>
        /// Справочник зарегестированных сообщений и их обработчиков.
        /// </summary>
        readonly Dictionary<DockingMessageType, List<Action<object>>> _subscribers;

        //Конструктор.
        public DockingMessageQueue()
        {
            _subscribers = new Dictionary<DockingMessageType, List<Action<object>>>();
        }

        public void Publish(DockingMessageType messageType, object args)
        {
            if (_subscribers.ContainsKey(messageType))
            {
                foreach (var subscriber in _subscribers[messageType])
                {
                    subscriber(args);
                }
            }
        }

        public void Register(DockingMessageType messageType, Action<object> action)
        {
            if (!_subscribers.ContainsKey(messageType))
            {
                _subscribers.Add(messageType, new List<Action<object>>());
            }
            _subscribers[messageType].Add(action);
        }
    }
}
