using Ovotan.Windows.Controls.EndPointManagement.Enums;
using System.Windows;
using System.Windows.Controls;

namespace Ovotan.Windows.Controls.EndPointManagement
{
    /// <summary>
    /// Класс описывает узел дерева конечной точки.
    /// </summary>
    public class TreeItem : TreeViewItem
    {
        /// <summary>
        /// Зависимое свойство. Поддерживает ли узел ленивую загрузку дочерних узлов.
        /// </summary>
        public static DependencyProperty IsLazyLoadingProperty;

        /// <summary>
        /// get,set - Тип узла.
        /// </summary>
        public TreeItemType Type { get; set; }

        /// <summary>
        /// get,set - Разрешена ли для узла отложенная загрузка
        /// </summary>
        public bool AllowLazyLoading { get; set; }

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
        static TreeItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeItem), new FrameworkPropertyMetadata(typeof(TreeViewItem)));
            IsLazyLoadingProperty = DependencyProperty.Register("IsLazyLoading", typeof(bool), typeof(TreeItem),
                new PropertyMetadata(false));
        }
    }
}
