using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Patient
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
