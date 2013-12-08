using System.Collections.ObjectModel;
using System;
using System.Linq;
using System.Collections.Generic;
using WpfApplication5.DataAccess;

namespace WpfApplication5.ViewModel
{
    public class AppointmentsViewModel:ViewModelBase
    {
        #region Fields

        readonly AppointmentRepository _appointmentRepository;

        #endregion // Fields
        
        #region Constructor

        public AppointmentsViewModel(AppointmentRepository appointmentRepository)
        {
            if (appointmentRepository == null)
                throw new ArgumentNullException("appointmentRepository");

            //base.DisplayName = Strings.AllCustomersViewModel_DisplayName;            

            _appointmentRepository = appointmentRepository;

            // Subscribe for notifications of when a new customer is saved.
            //_appointmentRepository.CustomerAdded += this.OnCustomerAddedToRepository;

            // Populate the AllCustomers collection with CustomerViewModels.
            this.CreateAllAppointments();              
        }

        void CreateAllAppointments()
        {
            List<AppointmentViewModel> all =
                (from appoint in _appointmentRepository.GetAppointments()
                 select new AppointmentViewModel(appoint, _appointmentRepository)).ToList();

            //foreach (AppointmentViewModel avm in all)
            //    avm.PropertyChanged += this.OnCustomerViewModelPropertyChanged;

            this.Appointments = new ObservableCollection<AppointmentViewModel>(all);
            //this.Appointments.CollectionChanged += this.OnCollectionChanged;
        }

        #endregion // Constructor
        
        #region Public Interface

        /// <summary>
        /// Returns a collection of all the CustomerViewModel objects.
        /// </summary>
        public ObservableCollection<AppointmentViewModel> Appointments { get; private set; }

        #endregion // Public Interface
    }
}
