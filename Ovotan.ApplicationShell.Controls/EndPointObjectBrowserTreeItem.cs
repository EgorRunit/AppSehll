using Ovotan.ApplicationShell.Controls.Configurations;
using System.Windows;
using System.Windows.Controls;

namespace Ovotan.ApplicationShell.Controls
{
    /// <summary>
    /// Класс описывает узел дерева ObjectBrowser
    /// </summary>
    public class EndPointObjectBrowserTreeItem : TreeViewItem
    {
        /// <summary>
        /// Зависимое свойство. Поддерживает ли узел ленивую загрузку дочерних узлов.
        /// </summary>
        public static DependencyProperty IsLazyLoadingProperty;

        /// <summary>
        /// get,set - Тип узла.
        /// </summary>
        public EndPointObjectBrowserTreeItemType Type { get; set; }

        /// <summary>
        /// Пользовательские данные узла.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Поддерживает ли узел ленивую загрузку дочерних узлов.
        /// </summary>
        public bool IsLazyLoading
        {
            get
            {
                return (bool)GetValue(IsLazyLoadingProperty);
            }
            set
            {
                SetValue(IsLazyLoadingProperty, value);
            }
        }

        /// <summary>
        /// Конструкторю
        /// </summary>
        static EndPointObjectBrowserTreeItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EndPointObjectBrowserTreeItem), new FrameworkPropertyMetadata(typeof(TreeViewItem)));
            IsLazyLoadingProperty = DependencyProperty.Register("IsLazyLoading", typeof(bool), typeof(EndPointObjectBrowserTreeItem),
                new PropertyMetadata(false));

        }
    }
}
