using AttendanceManagementSystem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceManagementSystem.Models.Repository
{
    public class MangerRepository : AttendanceSystemRepository<Manger>
    {
        DBContext db;
        public MangerRepository(DBContext _db)
        {
            db = _db;
        }
        public void add(Manger entity)
        {
            db.mangers.Add(entity);
            db.SaveChanges();
        }

     

        public void delete(int id)
        {
            var search = find(id);
            db.mangers.Remove(search);
            db.SaveChanges();
        }

        public Manger find(int id)
        {
            var FindId = db.mangers.SingleOrDefault(s => s.Id == id);
            return FindId;
        }

        public List<Manger> GETALL()
        {
            return new List<Manger>(db.mangers);
        }

        public List<Manger> search(string Name)
        {
            var result = db.mangers.Where(t => t.Name.Contains(Name)).ToList();
            return result;
        }

        public bool searchDate(string date, string name)
        {
            throw new NotImplementedException();
        }

        public void update(Manger newManger)
        {
            db.mangers.Update(newManger);
            db.SaveChanges();
        }
    }
}
