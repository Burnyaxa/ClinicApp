using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class DoctorDTO
    {
        public int? Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Specialty { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int Cabinet { get; set; }

        IEnumerable<VisitDTO> Visits { get; set; }
        IEnumerable<DoctorScheduleDTO> DoctorSchedules { get; set; }
        IEnumerable<AppointmentDTO> Appointments { get; set; }
    }
}
