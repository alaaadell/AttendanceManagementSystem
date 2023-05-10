using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceManagementSystem.ViewModel;

namespace AttendanceManagementSystem.models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<Trainee> trainees { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Manger> mangers { get; set; }
        public DbSet<Attendance> attendances { get; set; }
        
       
        
       // public DbSet<AttendanceManagementSystem.ViewModel.traineeViewModel> traineeViewModel { get; set; }
      
    }
}
