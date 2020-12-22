using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class PatientDTO
    {
        public int? Id { get; set; } 
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }

        public IEnumerable<VisitDTO> Visits { get; set; }
        public IEnumerable<AppointmentDTO> Appointments { get; set; }


    }
}
