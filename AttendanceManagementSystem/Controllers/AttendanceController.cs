using AttendanceManagementSystem.models;
using AttendanceManagementSystem.Models.Repository;
using AttendanceManagementSystem.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceManagementSystem.Controllers
{
    public class AttendanceController : Controller
    {

        private readonly AttendanceSystemRepository<Trainee> traineeRepo;
        private readonly AttendanceSystemRepository<Attendance> attendanceRepo;
        private readonly DBContext _db;

        public AttendanceController(AttendanceSystemRepository<Attendance> attendanceRepo, AttendanceSystemRepository<Trainee> traineeRepo, DBContext db)

        {
            _db = db;
            this.traineeRepo = traineeRepo;
            this.attendanceRepo = attendanceRepo;
        }
        // GET: AttendanceController
        public ActionResult Index()
        {

            return View(attendanceRepo.GETALL());
        }

      
        public ActionResult search(string traineeName)
        {
            
            //List<Attendance> attend = attendanceRepo.GETALL().Where(a=> a.traineeId.Name.Contains( traineeName)).ToList();
            return View("Index", attendanceRepo.search(traineeName));
        }

        // GET: AttendanceController/Details/5
        public ActionResult Details(int id)
        {
            var search = attendanceRepo.find(id);
            return View(search);
        }

        // GET: AttendanceController/Create
        public ActionResult Create()
        {
            var model = new AttendanceViewModel
            {
                trainees = traineeRepo.GETALL().ToList()
            };
            return View(model);
        }

        // POST: AttendanceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AttendanceViewModel model)
        {

            ///1- get all attendee attandances
            ///2- check with model date if it exists
            ///3- not exist add record if exist return with validation error
            ///
            var trainee1 = traineeRepo.find(model.traineeId);
            //if (trainee1.Id == -1)
            //{
            //    ModelState.AddModelError("", "Please select a tarinee");
                
            //}
          
            if (attendanceRepo.searchDate(model.Day,trainee1.Name) == true)
            {
               
                DateTime dateTime1 = Convert.ToDateTime(model.Start);
                DateTime dateTime2 = Convert.ToDateTime(model.Finish);
                TimeSpan span = dateTime2.Subtract(dateTime1);

                int Minutesdiff = Math.Abs(span.Minutes);
                int Hoursdiff = Math.Abs(span.Hours);
               
 
                double result = double.Parse(
                Hoursdiff.ToString() + "." + Minutesdiff.ToString() ,
               CultureInfo.InvariantCulture);

                //Console.WriteLine(diffOfDates.Minutes);
                //Console.WriteLine(diffOfDates.Hours);
                //Console.WriteLine(dateTime2);
                //Console.WriteLine(dateTime1);
                //Console.WriteLine(result);

                try
                {
                    var trainee = traineeRepo.find(model.traineeId);
                    Attendance attendance = new Attendance
                    {
                        Id = model.Id,
                        Day = model.Day,
                        Start = model.Start,
                        Finish = model.Finish,
                        Status = model.Status,
                        NoOfHours = result,
                        traineeId = trainee

                    };
                    attendanceRepo.add(attendance);
                    return RedirectToAction(nameof(Index));
                }


                catch
                {
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "This attendance has recorded before!");
                var modell = new AttendanceViewModel
                {
                    trainees = traineeRepo.GETALL().ToList()
                };
                return View(modell);

            }
        }



        // GET: AttendanceController/Edit/5
        public ActionResult Edit(int id)
        {
            var attendance = attendanceRepo.find(id);
            var viewattendance = new AttendanceViewModel
            {
                Id = attendance.Id,
                Start = attendance.Start,
                // traineeId = attendance.traineeId.Id,
                //trainees = traineeRepo.GETALL().ToList(),
                Finish = attendance.Finish,
                //NoOfHours=attendance.NoOfHours,
                Status = attendance.Status,
                Day = attendance.Day

            };
            return View(viewattendance);
        }

        // POST: AttendanceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AttendanceViewModel model)
        {
            try
            {

                DateTime dateTime1 = Convert.ToDateTime(model.Start);
                DateTime dateTime2 = Convert.ToDateTime(model.Finish);
                TimeSpan span = dateTime1.Subtract(dateTime2);
                //var diffOfDates = dateTime2 - dateTime1;

                int Minutesdiff = Math.Abs(span.Minutes);
                int Hoursdiff = Math.Abs(span.Hours);
               // int secdiff = Math.Abs(span.Seconds);

                double result = double.Parse(
                Hoursdiff.ToString() + "." + Minutesdiff.ToString(),
               CultureInfo.InvariantCulture);

                Attendance attendance = new Attendance
                {
                    Id = model.Id,
                    Start = model.Start,
                    Day = model.Day,
                    Finish = model.Finish,
                    Status = model.Status,
                    NoOfHours = result

                };
                attendanceRepo.update(attendance);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AttendanceController/Delete/5
        public ActionResult Delete(int id)
        {
            var attendance = attendanceRepo.find(id);
            return View(attendance);
        }

        // POST: AttendanceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                attendanceRepo.delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        //List<Trainee> FillSelectList()
        //{
        //    var trainee = traineeRepo.GETALL().ToList();
        //    trainee.Insert(0, new Trainee { Id = -1, Name = "___Please select a trainee__" });
        //    return trainee;
        //}
    }
}
