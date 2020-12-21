using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Models
{
    public class VIsitUpdateModel
    {
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int DoctorId { get; set; }

        public DateTime Date { get; set; }

        public string Diagnosis { get; set; }

        public string Note { get; set; }
    }
}
