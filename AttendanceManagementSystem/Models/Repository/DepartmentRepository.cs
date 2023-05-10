using AttendanceManagementSystem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceManagementSystem.Models.Repository
{
    public class DepartmentRepository : AttendanceSystemRepository<Department>
    {
        DBContext db;
        public DepartmentRepository(DBContext _db)
        {
            db = _db;
        }
        public void add(Department entity)
        {
            db.departments.Add(entity);
            db.SaveChanges();
        }

       

        public void delete(int id)
        {
            var search = find(id);
            db.departments.Remove(search);
            db.SaveChanges();

        }

        public Department find(int id)
        {
            var FindId= db.departments.SingleOrDefault(s => s.Id == id ) ;
            return FindId;
        }

        public List<Department> GETALL()
        {
            return new List<Department>(db.departments);
        }

        public List<Department> search(string Name)
        {
            var result = db.departments.Where(t => t.Name.Contains(Name)).ToList();
            return result;
        }

        public bool searchDate(string date, string name)
        {
            throw new NotImplementedException();
        }

        public void update( Department Newdep) { 
            
            db.departments.Update(Newdep); 
            db.SaveChanges();


        }
    }
}
