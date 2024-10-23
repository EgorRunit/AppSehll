using System.Windows.Controls;
using System.Windows;

namespace Spinner
{
    /// <summary>
    /// Interaction logic for CircularProgressBar.xaml
    /// </summary>
    public partial class CircularProgressBar : Viewbox
    {
        public static readonly RoutedEvent StartEvent =
            EventManager.RegisterRoutedEvent("StartSpinner",
                                             RoutingStrategy.Bubble,
                                             typeof(RoutedEventHandler),
                                             typeof(CircularProgressBar));
        public static readonly RoutedEvent StopEvent =
            EventManager.RegisterRoutedEvent("StopSpinner",
                                             RoutingStrategy.Bubble,
                                             typeof(RoutedEventHandler),
                                             typeof(CircularProgressBar));

        public CircularProgressBar()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public event RoutedEventHandler StartSpinner
        {
            add { AddHandler(StartEvent, value); }
            remove { RemoveHandler(StartEvent, value); }
        }

        public event RoutedEventHandler StopSpinner
        {
            add { AddHandler(StopEvent, value); }
            remove { RemoveHandler(StopEvent, value); }
        }

        public void Show()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(StartEvent);
            LayoutCanvas.RaiseEvent(newEventArgs);

            this.Visibility = Visibility.Visible;
        }

        public void Hide()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(StopEvent);
            LayoutCanvas.RaiseEvent(newEventArgs);

            this.Visibility = Visibility.Hidden;
        }
    }
}