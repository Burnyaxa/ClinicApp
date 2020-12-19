using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class AppointmentFreeTimeDTO
    {
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
        public List<TimeSpan> FreeTime { get; set; }
    }
}
