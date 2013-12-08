using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApplication5
{
    public static class CalendarBehavior
    {
        #region VisibilityChangedEvent

        public static readonly RoutedEvent VisibilityChangedEvent = 
            EventManager.RegisterRoutedEvent("VisibilityChanged", 
                                RoutingStrategy.Bubble, 
                                typeof(RoutedEventHandler),
                                typeof(CalendarBehavior));

        public static void AddVisibilityChangedHandler(DependencyObject d, RoutedEventHandler handler)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
            {
                uie.AddHandler(CalendarBehavior.VisibilityChangedEvent, handler);
            }
        }

        public static void RemoveVisibilityChangedHandler(DependencyObject d, RoutedEventHandler handler)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
            {
                uie.RemoveHandler(CalendarBehavior.VisibilityChangedEvent, handler);
            }
        }

        #endregion // VisibilityChangedEvent

        #region SelectedDateCommand

        public static DependencyProperty SelectedDateCommandProperty =
            DependencyProperty.RegisterAttached("SelectedDateCommand",
                                    typeof(ICommand),
                                    typeof(CalendarBehavior),
                                    new FrameworkPropertyMetadata(null, new
            PropertyChangedCallback(CalendarBehavior.SelectedDateChanged)));

        public static void SetSelectedDateCommand(DependencyObject target, ICommand value)
        {
            target.SetValue(CalendarBehavior.SelectedDateCommandProperty, value);
        }

        public static ICommand GetSelectedDateCommand(DependencyObject target)
        {
            return (ICommand)target.GetValue(SelectedDateCommandProperty);
        }

        private static void SelectedDateChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            Calendar calendar = target as Calendar;
            if (calendar != null)
            {
                // If we're putting in a new command and there wasn't one already
                // hook the event
                if ((e.NewValue != null) && (e.OldValue == null))
                {
                    calendar.SelectedDatesChanged += element_SelectedDateChanged;
                }
                // If we're clearing the command and it wasn't already null
                // unhook the event
                else if ((e.NewValue == null) && (e.OldValue != null))
                {
                    calendar.SelectedDatesChanged -= element_SelectedDateChanged;
                }
            }
        }

        static void element_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UIElement element = (UIElement)sender;
            ICommand command = (ICommand)element.GetValue(CalendarBehavior.SelectedDateCommandProperty);
            command.Execute(null);
        }

        #endregion // SelectedDateCommand
    }
}