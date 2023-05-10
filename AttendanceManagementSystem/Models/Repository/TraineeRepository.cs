using AttendanceManagementSystem.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceManagementSystem.Models.Repository
{
    public class TraineeRepository : AttendanceSystemRepository<Trainee>
    {
        DBContext db;
        public TraineeRepository(DBContext _db)
        {
            db = _db;
        }
        public void add(Trainee entity)
        {
            db.trainees.Add(entity);
            db.SaveChanges();
        }

       
        public void delete(int id)
        {
            var search = find(id);
            db.trainees.Remove(search);
            db.SaveChanges();

        }

        public Trainee find(int id)
        {
            var FindId = db.trainees.Include(s => s.departmentId).Include(s=>s.managerId).SingleOrDefault(s => s.Id == id);
            return FindId;
        }

        public List<Trainee> GETALL()
        {
            return new List<Trainee>(db.trainees); 
        }

        public List<Trainee> search(string Name)
        {
            var result = db.trainees.Where(t => t.Name.Contains(Name)).ToList();
            return result;
        }

        public bool searchDate(string date, string name)
        {
            throw new NotImplementedException();
        }

        public void update( Trainee newtrainee)
        {
            db.trainees.Update(newtrainee);
            db.SaveChanges();
        }
    }
}
