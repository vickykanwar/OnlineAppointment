using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineAppointment.Models
{
    public class CustomerMaster
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }

        public List<AppointmentMaster> AppointmentMasters { get; set; }
    }
}