using AttendanceManagementSystem.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceManagementSystem.Models.Repository
{
    public class AttendanceRepository : AttendanceSystemRepository<Attendance>
    {
        DBContext db;
        public AttendanceRepository(DBContext _db)
        {
            db = _db;
        }
        public void add(Attendance entity)
        {
            db.attendances.Add(entity);
            db.SaveChanges();
        }

       

        public void delete(int id)
        {
            var search = find(id);
            db.attendances.Remove(search);
            db.SaveChanges();
        }

        public Attendance find(int id)
        {
            var FindId = db.attendances.Include(s => s.traineeId).SingleOrDefault(s => s.Id == id);
            return FindId;
        }
        public List<Attendance> GETALL()
        {
            return new List<Attendance>(db.attendances.Include(s=>s.traineeId));
        }


        public void update( Attendance newattendance)
        {
            db.attendances.Update(newattendance);
            db.SaveChanges();
        }
        public List<Attendance> search(string TraineeName)
        {
            var result = db.attendances.Include(s => s.traineeId).Where(t => t.traineeId.Name.Contains(TraineeName)).ToList();
            return result;
        }
        public bool searchDate(string date,string name)
        {
            var result = db.attendances.Include(s => s.traineeId).Where(t => t.Day.Contains(date)&& t.traineeId.Name.Contains(name)).ToList();
            if (result.Count==0)
            return true ;
            return false;
        }
    }
}
