using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class DoctorScheduleDTO
    {
        public int? Id { get; set; }
        public int DoctorId { get; set; }

        public string DoctorLastName { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorPatronymic { get; set; }
        public string DoctorSpecialty { get; set; }

        public Days Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
