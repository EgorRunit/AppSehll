using Ovotan.Controls.Docking.Enums;

namespace Ovotan.Controls.Docking.Interfaces
{
    /// <summary>
    /// Интерфейс описывает очередь docking сообщений.
    /// </summary>
    public interface IDockingMessageQueue
    {
        /// <summary>
        /// Опиьликовать сообщение в очереди.
        /// </summary>
        /// <param name="messageType">Тип сообщения.</param>
        /// <param name="args">Аргументы сообщения.</param>
        void Publish(DockingMessageType messageType, object args);
        /// <summary>
        /// Зарегиестрировать новый обработчик сообщения.
        /// </summary>
        /// <param name="messageType">Тип сообщения.</param>
        /// <param name="callback">Ссылка на обработчик события</param>
        void Register(DockingMessageType messageType, Action<object> callback);
    }
}
