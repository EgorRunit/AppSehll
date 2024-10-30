using System.Collections;
using Ovotan.Windows.Controls.Controls;
using Ovotan.Windows.Controls.Docking.Interfaces;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Markup;
using System.Collections.ObjectModel;
using Ovotan.Windows.Controls.Docking;

namespace Ovotan.Windows.Controls.EndPointManagement
{
    [ContentProperty("ToolbarElements")]
    public class SiteHostDocumentDataGrid : ContentControl, ISiteHostDocument
    {
        static DependencyProperty ToolbarElementsProperty;


        DataGridDocument _dataGridDocument;
        Rectangle _busyIndecator;

        public bool IsStatic { get;  protected set; }
        public Guid ID { get; protected set; }
        public string Header { get; set; }

        public ICommand DataBindCommand { get; set; }

        public ObservableCollection<FrameworkElement> ToolbarElements
        {
            get
            {
                return GetValue(ToolbarElementsProperty) as ObservableCollection<FrameworkElement>;
            }
            set
            {
                SetValue(ToolbarElementsProperty, value);
            }
        }

        static SiteHostDocumentDataGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SiteHostDocumentDataGrid), new FrameworkPropertyMetadata(typeof(SiteHostDocumentDataGrid)));
            ToolbarElementsProperty = DependencyProperty.Register("ToolbarElements", typeof(ObservableCollection<FrameworkElement>), typeof(SiteHostTabControl),
                new FrameworkPropertyMetadata(new ObservableCollection<FrameworkElement>(), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
        }

        void _refresh()
        {
            if(DataBindCommand != null)
            {
                DataBindCommand.Execute(this);
                _busyIndecator.Visibility = Visibility.Visible;
                Cursor = Cursors.Wait;
            }
        }


        public SiteHostDocumentDataGrid()
        {
        }

        public void DataBind(IEnumerable values)
        {
            _dataGridDocument.ItemsSource = values;
            Cursor = null;
            _busyIndecator.Visibility=Visibility.Collapsed;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            DefaultStyleKey = typeof(SiteHostDocumentDataGrid);
        }



        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _dataGridDocument = Template.FindName("MainDataGrid", this) as DataGridDocument;
            _busyIndecator = Template.FindName("BusyIndecator", this) as Rectangle;
            (Template.FindName("RefreshButton", this) as Button).Click += (s, a) => _refresh();
            //(Template.FindName("MainToolbar", this) as ToolBar).ItemsSource = ToolbarElements;
            _refresh();
        }

    }
}
