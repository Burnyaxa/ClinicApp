using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public enum Days
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    public class DoctorSchedule
    {
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        [ForeignKey("Day")]
        public int DayId { get; set; }
        [EnumDataType(typeof(Days))]
        public Days Day { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
