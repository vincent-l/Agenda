using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfApplication5.ViewModel;
using WpfApplication5.DataAccess;

namespace WpfApplication5.DesignViewModel
{
    public class DesignAppointmentsViewModel : AppointmentsViewModel
    {
        public DesignAppointmentsViewModel()
            : base(new AppointmentRepository("Data/appointments.xml"))
        {
        }
    }
}
