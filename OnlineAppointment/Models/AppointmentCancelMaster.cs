using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineAppointment.Models
{
    public class AppointmentCancelMaster
    {
        public int ID { get; set; }
        public int AppointmentMasterID { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Cancel Date")]
        public Nullable<DateTime> CancelDate { get; set; }
        public string Reason { get; set; }

        public AppointmentMaster AppointmentMaster { get; set; }
    }
}