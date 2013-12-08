using System;
using System.ComponentModel;

namespace WpfApplication5.Model
{
    public class Appointment : IDataErrorInfo
    {
        #region Creation

        public static Appointment CreateNewAppointment()
        {
            return new Appointment();
        }

        public static Appointment CreateAppointment(
            string eventTitle,
            string notes,
            DateTime? from,
            DateTime? to,
            bool allday)
        {
            return new Appointment
            {
                EventTitle = eventTitle,
                Notes = notes,
                From = from,
                To = to,
                Allday = allday
            };
        }

        protected Appointment()
        {
        }

        #endregion // Creation

        #region State Properties

        /// <summary>
        /// Gets/sets the title for the appointment.
        /// </summary>
        public string EventTitle { get; set; }

        /// <summary>
        /// Gets/sets the description for the appointment.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets/sets the start date and time for the appointment.
        /// If the appointment is a memo, time is not set.
        /// </summary>
        public DateTime? From { get; set; }

        /// <summary>
        /// Gets/sets the end date and time for the appointment.
        /// If the appointment is a memo, this value is not set.
        /// </summary>
        public DateTime? To { get; set; }

        /// <summary>
        /// Gets/sets wether the appointment is a memo or an event.
        /// The default value is false.
        /// </summary>
        public bool Allday { get; set; }

        #endregion // State Properties

        #region IDataErrorInfo implementation

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string propertyName]
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
