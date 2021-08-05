using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineAppointment.Models
{
    public class ServiceMaster
    {
        public int ID { get; set; }
        public string ServiceName { get; set; }

        public List<AppointmentMaster> AppointmentMasters { get; set; }
    }
}