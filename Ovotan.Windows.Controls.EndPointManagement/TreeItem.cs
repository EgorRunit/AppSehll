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
        public static DependencyProperty IsChildrenLoadedProperty;
        /// <summary>
        /// 
        /// </summary>
        public static DependencyProperty AllowLazyLoadingProperty;

        /// <summary>
        /// get,set - Тип узла.
        /// </summary>
        public TreeItemType Type { get; set; }

        /// <summary>
        /// get,set - Разрешена ли для узла отложенная загрузка потомков.
        /// </summary>
        public bool AllowLazyLoading
        {
            get
            {
                return (bool)GetValue(AllowLazyLoadingProperty);
            }
            set
            {
                SetValue(AllowLazyLoadingProperty, value);
            }
        }

        /// <summary>
        /// Потомки были згружены или нет.
        /// </summary>
        public bool IsChildrenLoaded
        {
            get
            {
                return (bool)GetValue(IsChildrenLoadedProperty);
            }
            set
            {
                SetValue(IsChildrenLoadedProperty, value);
            }
        }

        /// <summary>
        /// Конструкторю
        /// </summary>
        static TreeItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeItem), new FrameworkPropertyMetadata(typeof(TreeViewItem)));
            IsChildrenLoadedProperty = DependencyProperty.Register("IsChildrenLoaded", typeof(bool), typeof(TreeItem),
                new PropertyMetadata(false));
            AllowLazyLoadingProperty = DependencyProperty.Register("AllowLazyLoading", typeof(bool), typeof(TreeItem),
                new PropertyMetadata(false));
        }
    }
}
