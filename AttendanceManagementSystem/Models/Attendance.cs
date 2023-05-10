using System;

namespace AttendanceManagementSystem.models
{
    public class Attendance
    {
        public int Id { get; set; }
        public Trainee traineeId { get; set; }
        public string Day { get; set; }
        public string Start { get; set; }
        public string Finish { get; set; }
        public string Status { get; set; }
        public double NoOfHours { get; set; }

    }
}
