using System.Windows;
using System.Windows.Controls;

namespace WpfApplication5.View
{
    /// <summary>
    /// Interaction logic for CalendarView.xaml
    /// </summary>
    public partial class CalendarView : UserControl
    {
        public CalendarView()
        {
            InitializeComponent();
        }

        private void calendar_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(CalendarBehavior.VisibilityChangedEvent, this);
            calendar.RaiseEvent(args);
        }
    }
}
