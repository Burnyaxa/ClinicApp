using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Models
{
    public class DoctorUpdateModel
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public string Specialty { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public int Cabinet { get; set; }
    }
}
