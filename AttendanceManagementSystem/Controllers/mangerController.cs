using AttendanceManagementSystem.models;
using AttendanceManagementSystem.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceManagementSystem.Controllers
{
    public class mangerController : Controller

    {

        private readonly AttendanceSystemRepository<Manger> mangerRepo;
        public mangerController(AttendanceSystemRepository<Manger> mangerRepo)

        {
            this.mangerRepo = mangerRepo;


        }
        // GET: mangerController
        public ActionResult Index()
        {
            return View(mangerRepo.GETALL());
        }

        public ActionResult search(string mangerName)
        {

            //List<Attendance> attend = attendanceRepo.GETALL().Where(a=> a.traineeId.Name.Contains( traineeName)).ToList();
            return View("Index", mangerRepo.search(mangerName));
        }
        // GET: mangerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: mangerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: mangerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Manger manger)
        {
            try
            {
                mangerRepo.add(manger);
                return RedirectToAction(nameof(Index));
               
            }
            catch
            {
                return View();
            }
        }

        // GET: mangerController/Edit/5
        public ActionResult Edit(int id)
        {
            var manger = mangerRepo.find(id);
            return View(manger);
        }

        // POST: mangerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Manger manger)
        {
            try
            {

                var newmanger= mangerRepo.find(id);
                newmanger.Name =manger.Name;
                newmanger.Eamil = manger.Eamil;
               mangerRepo.update(newmanger);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: mangerController/Delete/5
        public ActionResult Delete(int id)
        {
            var manger = mangerRepo.find(id);
            return View(manger);
        }

        // POST: mangerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                mangerRepo.delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
