using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Models
{
    public class DoctorScheduleCreateModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public Days Day { get; set; }
        [Required]
        public string StartTime { get; set; }
        [Required]
        public string EndTime { get; set; }
    }
}
