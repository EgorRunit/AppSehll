using Ovotan.ApplicationShell.Controls.Dialogs;
using Ovotan.ApplicationShell.Controls.ToolbarElements;
using Ovotan.Controls.Docking.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Ovotan.ApplicationShell.Controls
{
    /// <summary>
    /// Базовый класс для менеджера конечной точки.
    /// </summary>
    public class EndPointManager : ContentControl
    {
        /// <summary>
        /// Очередь сообщений докинга.
        /// </summary>
        protected IDockingMessageQueue dockingMessageQueue;
        /// <summary>
        /// Экземпляр toolbar над деревом.
        /// </summary>
        protected ToolBar toolBar;
        /// <summary>
        /// Экземпляр дерева иерархии конечной точки.
        /// </summary>
        protected TreeView treeView;

        /// <summary>
        /// Название конечной точки.
        /// </summary>
        public string Header { get; protected set; }

        public ObservableCollection<ToolbarElementBase> ToolbarActions { get; protected set; }

        /// <summary>
        /// Коснтруктор.
        /// </summary>
        static EndPointManager()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EndPointManager), new FrameworkPropertyMetadata(typeof(EndPointManager)));
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        public EndPointManager()
        {
            ToolbarActions = new ObservableCollection<ToolbarElementBase>();
        }

        /// <summary>
        /// Применение шаблона и стилей для элемента EndPointManager.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            toolBar = Template.FindName("Toolbar", this) as ToolBar;
            treeView = Template.FindName("TreeView", this) as TreeView;
        }

        /// <summary>
        /// Запуск управления конечной точкой.
        /// </summary>
        /// <param name="dockingMessageQueue">Очередь сообщений докинга.</param>
        public virtual void Start(IDockingMessageQueue dockingMessageQueue)
        {
            this.dockingMessageQueue = dockingMessageQueue;
        }

        protected void showDialog<T>(DialogManagerType type, Action<T> callbac)
        {
            Window wnd = null;
            switch (type)
            {
                case DialogManagerType.AddGroupFolder:
                    wnd = new AddGroupFolderDialog();
                    break;
                default:
                    throw new Exception("eee");
            }
            wnd.Owner = Application.Current.MainWindow;
            wnd.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            if (wnd.ShowDialog() == true)
            {
                callbac((T)wnd.Content);
            }
        }
    }
}
