namespace AttendanceManagementSystem.models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public Manger managerId { get; set; }
        public Department departmentId { get; set; }

    }
}
