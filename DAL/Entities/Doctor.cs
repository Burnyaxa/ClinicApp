﻿using DAL.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Doctor : Entity<int>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Specialty { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; } 
        public int Cabinet { get; set; }

        public IEnumerable<DoctorSchedule> Schedules { get; set; }
        public IEnumerable<Visit> Visits { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}