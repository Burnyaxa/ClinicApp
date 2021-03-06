﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class VisitDTO
    {
        public int? Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        public string PatientLastName { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientPatronymic { get; set; }
        public DateTime PatientDateOfBirth { get; set; }

        public string DoctorLastName { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorPatronymic { get; set; }
        public string DoctorSpecialty { get; set; }

        public DateTime Date { get; set; }
        public string Diagnosis { get; set; }
        public string Note { get; set; }
    }
}
