using System;

namespace WpfApplication5.ViewModel
{
    public class CalendarViewModel : WorkspaceViewModel
    {
        DateTime _currentDate = DateTime.Today;
        DateTime _calendarDisplayDate;

        public DateTime CalendarDisplayDate
        {
            get
            {
                return _calendarDisplayDate;
            }
            set
            {
                if (value == _calendarDisplayDate)
                    return;

                _calendarDisplayDate = value;

                base.RaisePropertyChanged("CalendarDisplayDate");
            }
        }

        public DateTime CurrentDate
        {
            get { return _currentDate; }
            set
            {
                if (value == _currentDate)
                    return;

                this._currentDate = value;

                base.RaisePropertyChanged("CurrentDate");
            }
        }
    }
}
