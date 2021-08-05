using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineAppointment.Models
{
    public class SlotTimeMaster
    {
        public int ID { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Slot Time")]
        public Nullable<DateTime> SlotDateTime { get; set; }

        public List<AppointmentMaster> AppointmentMasters { get; set; }
    }
}