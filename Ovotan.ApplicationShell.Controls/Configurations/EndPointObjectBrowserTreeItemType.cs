namespace Ovotan.ApplicationShell.Controls.Configurations
{
    /// <summary>
    /// Перичесление описывает типы узлов дерева обозревателя конечной точки.
    /// </summary>
    public enum EndPointObjectBrowserTreeItemType
    {
        /// <summary>
        /// Узел создается динамически от контекста.
        /// </summary>
        Dynamic,
        /// <summary>
        /// Узел содержит конфигурацию и подлежит сохранению.
        /// </summary>
        Configuration
    }
}
