using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Models
{
    public class AppointmentFreeTimeModel
    {
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public List<TimeSpan> FreeTime { get; set; }
    }
}
