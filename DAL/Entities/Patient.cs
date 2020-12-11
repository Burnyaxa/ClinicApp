using DAL.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Patient : Entity<int>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<Visit> Visits { get; set; }
    }
}
