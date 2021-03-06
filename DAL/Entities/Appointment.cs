﻿using DAL.Entities.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public enum AppointmentStatus
    {
        Awaiting,
        Completed,
        Cancelled,
        Delayed
    }

    public class Appointment : Entity<int>
    {
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime Date { get; set; }
        [EnumDataType(typeof(AppointmentStatus))]
        public AppointmentStatus Status { get; set; }
    }
}
