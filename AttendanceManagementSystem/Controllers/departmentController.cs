using AttendanceManagementSystem.models;
using AttendanceManagementSystem.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace AttendanceManagementSystem.Controllers
{
    public class departmentController : Controller

    {
      
        private readonly AttendanceSystemRepository<Department> departmentRepo;
        public departmentController(AttendanceSystemRepository<Department> departmentRepo)

        {
            this.departmentRepo = departmentRepo;
          

        }
        // GET: departmentController
        public ActionResult Index()
        {
        
            return View(departmentRepo.GETALL());
        }
        public ActionResult search(string depName)
        {

            //List<Attendance> attend = attendanceRepo.GETALL().Where(a=> a.traineeId.Name.Contains( traineeName)).ToList();
            return View("Index", departmentRepo.search(depName));
        }
        // GET: departmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: departmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: departmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            try
            {
                departmentRepo.add(department);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: departmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var dep = departmentRepo.find(id);
            return View(dep);
        }

        // POST: departmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Department dep)
        {
            try
            {
                var newdep= departmentRepo.find(id);
                newdep.Name = dep.Name;
                departmentRepo.update(newdep);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: departmentController/Delete/5
        public ActionResult Delete(int id)

        {
            var dep = departmentRepo.find(id);
            return View(dep);
           
        }

        // POST: departmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Department dep)
        {
            try
            {
              
                departmentRepo.delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
