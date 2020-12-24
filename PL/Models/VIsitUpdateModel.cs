using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Models
{
    public class VisitUpdateModel
    {
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Diagnosis { get; set; }
        [Required]
        public string Note { get; set; }
    }
}
