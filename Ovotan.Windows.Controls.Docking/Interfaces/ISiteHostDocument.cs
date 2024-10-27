namespace Ovotan.Windows.Controls.Docking.Interfaces
{
    /// <summary>
    /// Интерфейс описывает документ SiteHost.
    /// </summary>
    public interface ISiteHostDocument
    {
        /// <summary>
        /// get - Название документа.
        /// </summary>
        string Header { get; }

        /// <summary>
        /// Уникальный идентфикатор документа.
        /// </summary>
        Guid ID { get => Guid.NewGuid(); }
    
        void Close() { }

        void Refresh() { }
    }
}
