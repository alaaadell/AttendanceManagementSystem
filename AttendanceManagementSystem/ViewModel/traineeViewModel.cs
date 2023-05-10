using AttendanceManagementSystem.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceManagementSystem.ViewModel
{
    public class traineeViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [RegularExpression("[a-zA-Z][a-zA-Z ]+", ErrorMessage = "Only Alphabets allowed.")]
        public string Name { get; set; }
        public int managerid { get; set; }
        public int departmentid { get; set; }
        public List<Manger> mangers { get; set; }
        public List<Department> departments { get; set; }
    }
}
