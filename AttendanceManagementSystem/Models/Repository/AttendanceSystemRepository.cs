using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceManagementSystem.Models.Repository
{
     public interface AttendanceSystemRepository<TEntity>
    {
        TEntity find(int id);
        void add(TEntity entity);
        void update( TEntity entity);
        void delete(int id);
        public List<TEntity> GETALL();
        public List<TEntity> search(string Name);
        public bool searchDate(string date, string name);
    }
}
