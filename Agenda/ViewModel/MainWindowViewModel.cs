using System;
using System.Windows;
using System.Windows.Input;
using WpfApplication5.DataAccess;
using WpfApplication5.Properties;

namespace WpfApplication5.ViewModel
{
    /// <summary>
    /// The ViewModel for the application's main window.
    /// </summary>
    class MainWindowViewModel : WorkspaceViewModel
    {
        #region Fields

        RelayCommand _nextDayCommand;
        RelayCommand _previousDayCommand;

        RelayCommand _calendarOpenCommand;
        RelayCommand _eventFormOpenCommand;
        RelayCommand _memoFormOpenCommand;

        readonly AppointmentRepository _appointmentRepository;
        
        AppointmentsViewModel _appointments;
        CalendarViewModel _calendar;
        EventFormViewModel _eventForm;
        MemoFormViewModel _memoForm;

        #endregion // Fields

        #region Constructor

        public MainWindowViewModel(string appointmentDataFile)
        {
            base.DisplayName = Strings.MainWindowViewModel_DisplayName;

            _appointmentRepository = new AppointmentRepository(appointmentDataFile);
        }

        #endregion // Constructor

        #region Commands

        #region Day Navigation Commands

        public ICommand NextDayCommand
        {
            get
            {
                if (_nextDayCommand == null)
                    _nextDayCommand = new RelayCommand(param => this.NavigateToNextDay());

                return _nextDayCommand;
            }
        }

        void NavigateToNextDay()
        {
            _calendar.CurrentDate += TimeSpan.FromDays(1);
        }

        public ICommand PreviousDayCommand
        {
            get
            {
                if (_previousDayCommand == null)
                    _previousDayCommand = new RelayCommand(param => this.NavigateToPreviousDay());

                return _previousDayCommand;
            }
        }

        void NavigateToPreviousDay()
        {
            _calendar.CurrentDate -= TimeSpan.FromDays(1);
        }

        #endregion // #region Day Navigation Commands

        #region Calendar Commands

        public ICommand CalendarOpenCommand
        {
            get
            {
                if (_calendarOpenCommand == null)
                    _calendarOpenCommand = new RelayCommand(param => this.OpenCalendar());

                return _calendarOpenCommand;
            }
        }

        void OpenCalendar()
        {
            EventHandler handler = null;
            handler = delegate
            {
                _calendar.RequestClose -= handler;
                _calendar.Visibility = Visibility.Collapsed;
            };
            _calendar.RequestClose += handler;
            _calendar.CalendarDisplayDate = _calendar.CurrentDate;
            _calendar.Visibility = Visibility.Visible;
        }

        #endregion // Calendar Commands

        #region EventForm Commands

        public ICommand EventFormOpenCommand
        {
            get
            {
                if (_eventFormOpenCommand == null)
                    _eventFormOpenCommand = new RelayCommand(param => this.OpenEventForm());

                return _eventFormOpenCommand;
            }
        }

        void OpenEventForm()
        {
            EventHandler handler = null;
            handler = delegate
            {
                _eventForm.RequestClose -= handler;
                _eventForm.Visibility = Visibility.Collapsed;
            };
            _eventForm.RequestClose += handler;
            _eventForm.Visibility = Visibility.Visible;
        }

        #endregion // EventForm Commands

        #region MemoForm Commands

        public ICommand MemoFormOpenCommand
        {
            get
            {
                if (_memoFormOpenCommand == null)
                    _memoFormOpenCommand = new RelayCommand(param => this.OpenMemoForm());

                return _memoFormOpenCommand;
            }
        }

        void OpenMemoForm()
        {
            EventHandler handler = null;
            handler = delegate
            {
                _memoForm.RequestClose -= handler;
                _memoForm.Visibility = Visibility.Collapsed;
            };
            _memoForm.RequestClose += handler;
            _memoForm.Visibility = Visibility.Visible;
        }

        #endregion // MemoForm Commands

        #endregion // Commands

        #region Public Interface

        #region Appointments

        /// <summary>
        /// Returns a read-only list of appointments 
        /// that the UI can display.
        /// </summary>
        public AppointmentsViewModel Appointments
        {
            get
            {
                if (_appointments == null)
                    _appointments = new AppointmentsViewModel(_appointmentRepository);
                return _appointments;
            }
        }

        #endregion // Appointments

        #region Calendar

        /// <summary>
        /// Returns the calendar
        /// that the UI can display.
        /// </summary>
        public CalendarViewModel Calendar
        {
            get
            {
                if (_calendar == null)
                    _calendar = new CalendarViewModel();
                return _calendar;
            }
        }

        #endregion // Calendar

        #region EventForm

        /// <summary>
        /// Returns the event form
        /// that the UI can display.
        /// </summary>
        public EventFormViewModel EventForm
        {
            get
            {
                if (_eventForm == null)
                    _eventForm = new EventFormViewModel();
                return _eventForm;
            }
        }

        #endregion // EventForm

        #region MemoForm

        /// <summary>
        /// Returns the memo form
        /// that the UI can display.
        /// </summary>
        public MemoFormViewModel MemoForm
        {
            get
            {
                if (_memoForm == null)
                    _memoForm = new MemoFormViewModel();
                return _memoForm;
            }
        }

        #endregion // MemoForm

        #endregion // Public Interface
    }
}
