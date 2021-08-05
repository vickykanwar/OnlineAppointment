using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineAppointment.Models
{
    public class AppointmentMaster
    {
        public int ID { get; set; }
        [Display(Name = "Service")]
        public int ServiceMasterID { get; set; }
        [Display(Name = "Customer")]
        public int CustomerMasterID { get; set; }
        [Display(Name = "Slot")]
        public int SlotTimeMasterID { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Appointment Date")]
        public Nullable<DateTime> Date { get; set; }

        public List<AppointmentCancelMaster> AppointmentCancelMasters { get; set; }
        public List<ProcessMaster> ProcessMasters { get; set; }
        public ServiceMaster ServiceMaster { get; set; }
        public CustomerMaster CustomerMaster { get; set; }
        public SlotTimeMaster SlotTimeMaster { get; set; }

    }
}