namespace Ovotan.Windows.Controls.EndPointManagement.Enums
{
    /// <summary>
    /// Перичесление описывает типы узлов дерева обозревателя конечной точки.
    /// </summary>
    public enum TreeItemType
    {
        /// <summary>
        /// Узел создается динамически от контекста.
        /// </summary>
        Dynamic,
        /// <summary>
        /// Узел содержит конфигурацию и подлежит сохранению.
        /// </summary>
        Configuration,
        /// <summary>
        /// Узел содержит конфигурацию для подключения к конечной точки и подлежит сохранению (HttpClientBase).
        /// </summary>
        BaseHttpConfiguration,

    }
}
