using AttendanceManagementSystem.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceManagementSystem.ViewModel
{
    public class AttendanceViewModel
    {
        public int Id { get; set; }
        public int traineeId { get; set; }
        [Required]
        public string Day { get; set; }
       
        public string Start { get; set; }
      
        public string Finish { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Alphabets allowed.")]
        public string Status { get; set; }
        public double NoOfHours { get; set; }
      
        public List<Trainee>trainees { get; set; }
    }
}
