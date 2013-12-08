using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfApplication5.ViewModel;
using WpfApplication5.Model;
using WpfApplication5.DataAccess;
using WpfApplication5.DesignModel;

namespace WpfApplication5.DesignViewModel
{
    class DesignAppointmentViewModel : AppointmentViewModel
    {
        public DesignAppointmentViewModel()
            : base(new DesignAppointment(), new AppointmentRepository("Data/appointments.xml"))
        {
        }
    }
}
