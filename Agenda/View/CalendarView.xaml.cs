using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication5.View
{
    /// <summary>
    /// Interaction logic for CalendarView.xaml
    /// </summary>
    public partial class CalendarView : UserControl
    {
        public static readonly RoutedEvent VisibilityChangedEvent;

        static CalendarView()
        {
            VisibilityChangedEvent = EventManager.RegisterRoutedEvent("VisibilityChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CalendarView));
        }

        public CalendarView()
        {
            InitializeComponent();
        }

        public event RoutedEventHandler VisibilityChanged
        {
            add { AddHandler(VisibilityChangedEvent, value); }
            remove { RemoveHandler(VisibilityChangedEvent, value); }
        }

        protected virtual void OnVisibilityChanged()
        {
            RoutedEventArgs args = new RoutedEventArgs(VisibilityChangedEvent, this);
            RaiseEvent(args);
        }

        private void calendar_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            OnVisibilityChanged();
        }
    }
}
