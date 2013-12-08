using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using WpfApplication5.Model;
using WpfApplication5.DataAccess;
using System.Windows;
using WpfApplication5.Properties;

namespace WpfApplication5.ViewModel
{
    public class AppointmentViewModel : ViewModelBase, IDataErrorInfo
    {
        #region Fields

        readonly Appointment _appointment;
        readonly AppointmentRepository _appointmentRepository;
        //string _customerType;
        //string[] _customerTypeOptions;
        //bool _isSelected;
        //RelayCommand _saveCommand;

        #endregion // Fields

        #region Constructor

        public AppointmentViewModel(Appointment appointment, AppointmentRepository appointmentRepository)
        {
            if (appointment == null)
                throw new ArgumentNullException("appointment");

            if (appointmentRepository == null)
               throw new ArgumentNullException("appointmentRepository");

            _appointment = appointment;
            _appointmentRepository = appointmentRepository;
            //_customerType = Strings.CustomerViewModel_CustomerTypeOption_NotSpecified;
        }

        #endregion // Constructor

        #region Appointment Properties

        public string EventTitle
        {
            get { return _appointment.EventTitle; }
            set
            {
                if (value == _appointment.EventTitle)
                    return;

                _appointment.EventTitle = value;

                base.RaisePropertyChanged("EventTitle");
            }
        }
        public string Notes
        {
            get { return _appointment.Notes; }
            set
            {
                if (value == _appointment.Notes)
                    return;

                _appointment.Notes = value;

                base.RaisePropertyChanged("Notes");
            }
        }
        public DateTime? From
        {
            get { return _appointment.From; }
            set
            {
                if (value == _appointment.From)
                    return;

                _appointment.From = value;

                base.RaisePropertyChanged("From");
            }
        }
        public DateTime? To
        {
            get { return _appointment.To; }
            set
            {
                if (value == _appointment.To)
                    return;

                _appointment.To = value;

                base.RaisePropertyChanged("To");
            }
        }
        public bool Allday
        {
            get { return _appointment.Allday; }
            set
            {
                if (value == _appointment.Allday)
                    return;

                _appointment.Allday = value;

                base.RaisePropertyChanged("Allday");
            }
        }

        #endregion // Appointment Properties

        #region Presentation Properties

        public string GetTitle
        {
            get
            {
                if (Allday)
                    return Strings.AppointmentViewModel_DisplayName;
                else
                    return string.Format("{0:H:mm} - {1:H:mm}", this.From, this.To);
            }
        }

        #endregion

        #region IDataErrorInfo Members

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
