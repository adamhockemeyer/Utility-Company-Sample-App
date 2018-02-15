using System;

namespace Utility.Models
{
    public class Appointment
    {
        public string AppointmentType { get; set; }
        public DateTime ScheduledTime { get; set; }
        public string Status { get; set; }
        public string TechnicianName { get; set; }
        public string TechnicianPhone { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public string FullAddress => $"{Address1} {Address2} {City}, {State} {ZipCode}";
    }
}
