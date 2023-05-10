using System.ComponentModel.DataAnnotations;

namespace AttendanceManagementSystem.models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression("[a-zA-Z][a-zA-Z ]+", ErrorMessage = "Only Alphabets allowed.")]
        public string Name { get; set; }  
    }
}
