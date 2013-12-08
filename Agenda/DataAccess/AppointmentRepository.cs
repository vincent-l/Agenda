using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Resources;
using System.Windows;
using WpfApplication5.Model;

namespace WpfApplication5.DataAccess
{
    public class AppointmentRepository
    {
        #region Fields

        readonly List<Appointment> _appointments;

        #endregion // Fields

        #region Constructor

        /// <summary>
        /// Creates a new repository of appointments.
        /// </summary>
        /// <param name="appointmentDataFile">The relative path to an XML resource file that contains appointment data.</param>
        public AppointmentRepository(string appointmentDataFile)
        {
            _appointments = LoadAppointments(appointmentDataFile);
        }

        #endregion // Constructor        #region Public Interface

        #region Public Interface

        /// <summary>
        /// Returns a shallow-copied list of all appointments in the repository.
        /// </summary>
        public List<Appointment> GetAppointments()
        {
            return new List<Appointment>(_appointments);
        }

        #endregion // Public Interface

        #region Private Helpers

        static List<Appointment> LoadAppointments(string appointmentDataFile)
        {
            // In a real application, the data would come from an external source,
            // but for this demo let's keep things simple and use a resource file.
            using (Stream stream = GetResourceStream(appointmentDataFile))
            using (XmlReader xmlRdr = new XmlTextReader(stream))
                return
                    (from appointmentElem in XDocument.Load(xmlRdr).Element("Appointments").Elements("Appointment")
                     select Appointment.CreateAppointment(
                        (string)appointmentElem.Attribute("EventTitle"),
                        (string)appointmentElem.Attribute("Notes"),
                        (DateTime?)appointmentElem.Attribute("From"),
                        (DateTime?)appointmentElem.Attribute("To"),
                        (bool)appointmentElem.Attribute("Allday")
                         )).ToList();
        }

        static Stream GetResourceStream(string resourceFile)
        {
            Uri uri = new Uri(resourceFile, UriKind.RelativeOrAbsolute);

            StreamResourceInfo info = Application.GetResourceStream(uri);
            if (info == null || info.Stream == null)
                throw new ApplicationException("Missing resource file: " + resourceFile);

            return info.Stream;
        }

        #endregion // Private Helpers
    }
}
