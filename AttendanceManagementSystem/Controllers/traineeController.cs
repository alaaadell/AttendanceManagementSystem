using AttendanceManagementSystem.models;
using AttendanceManagementSystem.Models.Repository;
using AttendanceManagementSystem.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceManagementSystem.Controllers
{
    public class traineeController : Controller
    {
       
        private readonly AttendanceSystemRepository<Trainee>traineeRepo;
        private readonly AttendanceSystemRepository<Manger> mangerRepo;
        private readonly AttendanceSystemRepository<Department> depRepo;
        public traineeController(AttendanceSystemRepository<Trainee> traineeRepo, AttendanceSystemRepository<Manger> mangerRepo, AttendanceSystemRepository<Department> depRepo)

        {
            this.traineeRepo = traineeRepo;
            this.mangerRepo =mangerRepo;
            this.depRepo = depRepo;


        }
        // GET: traineeController
        public ActionResult Index()
        {
            return View(traineeRepo.GETALL());
        }
        public ActionResult search(string traineeName)
        {

            //List<Attendance> attend = attendanceRepo.GETALL().Where(a=> a.traineeId.Name.Contains( traineeName)).ToList();
            return View("Index", traineeRepo.search(traineeName));
        }
        // GET: traineeController/Details/5
        public ActionResult Details(int id)

        {
            var search = traineeRepo.find(id);
            return View(search);
        }

        // GET: traineeController/Create
        public ActionResult Create()
        {
            var model = new traineeViewModel
            {
                mangers = mangerRepo.GETALL().ToList(),
                departments = depRepo.GETALL().ToList()
            };
            return View(model);
        }

        // POST: traineeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(traineeViewModel model)
        {
            try
            {
                var manger = mangerRepo.find(model.managerid);
                var department = depRepo.find(model.departmentid);
                Trainee trainee = new Trainee
                {
                    Id = model.Id,
                    Email = model.Email,
                    Name=model.Name,
                    managerId = manger,
                    departmentId = department

                };
                traineeRepo.add(trainee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: traineeController/Edit/5
        public ActionResult Edit(int id)
        {
            var trainee = traineeRepo.find(id);
            var viewtrainee = new traineeViewModel
            {
                Id=trainee.Id,
                Name=trainee.Name,
                Email=trainee.Email,
                departmentid=trainee.departmentId.Id,
                managerid=trainee.managerId.Id,
                mangers=mangerRepo.GETALL().ToList(),
                departments = depRepo.GETALL().ToList(),

            };
            return View(viewtrainee);
        }

        // POST: traineeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, traineeViewModel model)
        {
            try
            {
                var manger = mangerRepo.find(model.managerid);
                var department = depRepo.find(model.departmentid);
                Trainee trainee = new Trainee
                {
                    Id = model.Id,
                    Email = model.Email,
                    Name = model.Name,
                    managerId = manger,
                    departmentId = department

                };
                traineeRepo.update(trainee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: traineeController/Delete/5
        public ActionResult Delete(int id)
        {
            var trainee=traineeRepo.find(id);
            return View(trainee);
        }

        // POST: traineeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                traineeRepo.delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
