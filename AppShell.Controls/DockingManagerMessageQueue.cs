using System;
using System.Collections.Generic;

namespace AppShell.Controls
{
    /// <summary>
    /// Очередь сообщенимй для DockingManager
    /// </summary>
    public class DockingManagerMessageQueue : IDockingManagerMessageQueue
    {
        /// <summary>
        /// Справочник зарегестированных сообщений и их обработчиков.
        /// </summary>
        readonly Dictionary<DockingManagerMessageType, List<Action<object>>> _subscribers;

        //Конструктор.
        public DockingManagerMessageQueue()
        {
            _subscribers = new Dictionary<DockingManagerMessageType, List<Action<object>>>();
        }

        /// <summary>
        /// Публикация сообщения в очередь сообщений.
        /// </summary>
        /// <param name="messageType">Тип сообщения.</param>
        /// <param name="args">Аргументы сообщения.</param>
        public void Publish(DockingManagerMessageType messageType, object args)
        {
            if (_subscribers.ContainsKey(messageType))
            {
                foreach (var subscriber in _subscribers[messageType])
                {
                    subscriber(args);
                }
            }
        }

        /// <summary>
        /// Регистрация обработки сообщения.
        /// </summary>
        /// <param name="messageType">Тип обрабатываемого сообщения.</param>
        /// <param name="args">Обработчик сообщения.</param>
        public void Register(DockingManagerMessageType messageType, Action<object> action)
        {
            if (!_subscribers.ContainsKey(messageType))
            {
                _subscribers.Add(messageType, new List<Action<object>>());
            }
            _subscribers[messageType].Add(action);
        }
    }
}
