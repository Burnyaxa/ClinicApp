using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public enum VisitStatus
    {
        Awaiting,
        Completed,
        Cancelled,
        Delayed
    }

    public class Visit
    {
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime Date { get; set; }
        [EnumDataType(typeof(VisitStatus))]
        public VisitStatus Status { get; set; }
        public string Diagnosis { get; set; }
        public string Note { get; set; }
    }
}
