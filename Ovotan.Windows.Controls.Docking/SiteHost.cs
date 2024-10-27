using Ovotan.Windows.Controls.Docking.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace Ovotan.Windows.Controls.Docking
{
    /// <summary>
    /// Контрол для отображения открытых документов.
    /// </summary>
    public class SiteHost : ContentControl, ISiteHost
    {

        //Экземпляр очереди сообщений элметов докинга.
        IDockingMessageQueue _dockingMessageQueue;
        TabControl _tabControl;
        Dictionary<Guid, TabItem> _documents;

        /// <summary>
        /// Отображить главное меню или нет.
        /// </summary>
        public bool ShowMainMenu {  get; set; }

        static SiteHost()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SiteHost), new FrameworkPropertyMetadata(typeof(SiteHost)));
        }


        public SiteHost(IDockingMessageQueue dockingMessageQueue)
        {
            _dockingMessageQueue = dockingMessageQueue;
        }

        public void AddDocument(ISiteHostDocument document)
        {
            if (!(document is FrameworkElement))
            {
                throw new Exception("Документ неверного типа");
            }
            if (_documents.ContainsKey(document.ID))
            {
                throw new Exception("ffff");
            }

            var tab = new TabItem() { Header = document.Header };
            tab.Content = document;
            _tabControl.Items.Add(tab);
            _documents.Add(document.ID, tab);
            _tabControl.SelectedIndex = _tabControl.Items.Count - 1;
        }

        public bool ContainsDocument(Guid id)
        {
            return _documents.ContainsKey(id);
        }

        public bool TryActivate(Guid id)
        {
            if(_documents.ContainsKey(id))
            {
                var index = _tabControl.Items.IndexOf(_documents[id]);
                _tabControl.SelectedIndex = index;
                (_documents[id].Content as ISiteHostDocument).Refresh();
                return true;
            }
            return false;
        }


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _tabControl = Template.FindName("TabControl", this) as TabControl;
            _documents = new Dictionary<Guid, TabItem>();
        }

    }
}
