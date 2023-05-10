using AttendanceManagementSystem.models;
using AttendanceManagementSystem.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceManagementSystem.Controllers
{
    public class ReportController : Controller
    {
        private readonly AttendanceSystemRepository<Trainee> traineeRepo;
        private readonly AttendanceSystemRepository<Attendance> attendanceRepo;
        private readonly DBContext _db;

        public ReportController(AttendanceSystemRepository<Attendance> attendanceRepo, AttendanceSystemRepository<Trainee> traineeRepo, DBContext db)

        {
            _db = db;
            this.traineeRepo = traineeRepo;
            this.attendanceRepo = attendanceRepo;
        }
        // GET: ReportController1
        public ActionResult Index()
        {
            return View(attendanceRepo.GETALL());
        }
        
        public ActionResult search(string traineeName)
        {

            //List<Attendance> attend = attendanceRepo.GETALL().Where(a=> a.traineeId.Name.Contains( traineeName)).ToList();
            return View("Index", attendanceRepo.search(traineeName));
        }

        // GET: ReportController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReportController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReportController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReportController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReportController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReportController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReportController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
