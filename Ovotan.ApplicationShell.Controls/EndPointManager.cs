using Ovotan.ApplicationShell.Controls.Configurations;
using Ovotan.ApplicationShell.Controls.Dialogs;
using Ovotan.ApplicationShell.Controls.Enums;
using Ovotan.ApplicationShell.Controls.ToolbarElements;
using Ovotan.Controls.Docking.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ovotan.ApplicationShell.Controls
{
    /// <summary>
    /// Базовый класс для менеджера конечной точки.
    /// </summary>
    public class EndPointManager : ContentControl, IDockPanelContent
    {
        /// <summary>
        /// Очередь сообщений докинга.
        /// </summary>
        protected IDockingMessageQueue dockingMessageQueue;
        /// <summary>
        /// Экземпляр сервиса конфигурации.
        /// </summary>
        protected EndPointConfigurations endPointConfigurations;
        /// <summary>
        /// Экземпляр toolbar над деревом.
        /// </summary>
        protected ToolBar toolBar;
        /// <summary>
        /// Экземпляр дерева иерархии конечной точки.
        /// </summary>
        protected EndPointObjectTree treeView;

        /// <summary>
        /// Название конечной точки.
        /// </summary>
        public string Header { get; protected set; }

        /// <summary>
        /// Коллекция элементов toolbar над деревом обозевателя конечной точки.
        /// </summary>
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

        public void ContentFocus()
        {
            FocusManager.SetFocusedElement(this, treeView);
            if (treeView.SelectedItem != null)
            {
                
                var treeViewItem = treeView.SelectedItem as TreeViewItem;
                treeViewItem.Focus();
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            toolBar = Template.FindName("Toolbar", this) as ToolBar;
            treeView = Template.FindName("TreeView", this) as EndPointObjectTree;
            treeView.AddHandler(TreeViewItem.ExpandedEvent, (RoutedEventHandler)_onExpandNode);
            LoadConfiguration();
        }

        /// <summary>
        /// Запуск управления конечной точкой.
        /// </summary>
        /// <param name="endPointConfigurations">Экземпляр сервиса конфигурации.</param>
        /// <param name="dockingMessageQueue">Очередь сообщений докинга.</param>
        public virtual void Start(EndPointConfigurations endPointConfigurations, IDockingMessageQueue dockingMessageQueue)
        {
            this.dockingMessageQueue = dockingMessageQueue;
            this.endPointConfigurations = endPointConfigurations;
        }

        /// <summary>
        /// Сохранение конфигурации конечной точки.
        /// </summary>
        public virtual void SaveConfiguration()
        {
        }

        /// <summary>
        /// Загрузка конфигурации конечной точки.
        /// </summary>
        public virtual void LoadConfiguration()
        {
        }

        /// <summary>
        /// Попытка раскрыть узел, у которого в свойствах установлена отложенная загрузка потомков.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public virtual async Task TryExpandNode(EndPointObjectBrowserTreeItem node)
        {
        }

        /// <summary>
        /// Октрывает диалог указанного типа и в случае успеха, возвращает
        /// результат его работы.
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого результата диалога.</typeparam>
        /// <param name="type">Тип необходимого диалога</param>
        /// <param name="callbac"></param>
        /// <exception cref="Exception"></exception>
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


        /// <summary>
        /// Обратчик события раскрытия узла дерева.
        /// </summary>
        void _onExpandNode(object sender, RoutedEventArgs e)
        {
            var treeViewItem = e.Source as EndPointObjectBrowserTreeItem;
            Mouse.SetCursor(Cursors.Wait);
            var task = Task.Run(async () => {
                await TryExpandNode(treeViewItem);
            });
            task.Wait();
        }
    }
}
