using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    class PatientDTO
    {
        public int Id { get; set; } 
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }

        IEnumerable<> Visits { get; set; }
        IEnumerable<> Appointments { get; set; }


    }
}
