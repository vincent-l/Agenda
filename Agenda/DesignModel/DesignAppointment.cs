using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfApplication5.Model;

namespace WpfApplication5.DesignModel
{
    public class DesignAppointment : Appointment
    {
        public DesignAppointment()
            : base()
        {
            base.EventTitle = "Rendez-vous coiffeur.";
            base.Notes = "Penser à retirer de l'argent au distributeur.";
            base.From = new DateTime(2013, 12, 25, 9, 30, 0);
            base.To = new DateTime(2013, 12, 25, 10, 0, 0);
            base.Allday = false;
        }
    }
}
