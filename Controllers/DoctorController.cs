using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dashbord.Data;
using dashbord.Models;
using Microsoft.EntityFrameworkCore;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dashbord.Controllers
{
    [Authorize]
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public DoctorController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var doctorList = _dbContext.Doctor.AsNoTracking().ToList();
            return View(doctorList);
        }
        [Authorize(Roles = "Admin")]

        public IActionResult DoneCreatD()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]

        public IActionResult DoneEditD()
        {
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult EditDoc(int id)
        {
            var doctor  =  GetDoctorByIdAsync(id).Result;
            return View(doctor);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> EditDocAsync(Doctor model)
        {
            var existingDoctor = await _dbContext.Doctor.FindAsync(model.doctorId);
            if (existingDoctor == null)
            {
                return NotFound();
            }

            // Mark the entity as modified and update the existing doctor
            _dbContext.Entry(existingDoctor).CurrentValues.SetValues(model);

            // Save changes to the database
            await _dbContext.SaveChangesAsync();

            return View(nameof(DoneEditD));
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("Doctor/Delete/{doctorId}")]
        public async Task<IActionResult> Delete(int doctorId)
        {
            var doctor = _dbContext.Doctor.FindAsync(doctorId).Result;
            if (doctor == null)
            {
                return NotFound();
            }

            _dbContext.Doctor.Remove(doctor);
            await _dbContext.SaveChangesAsync();
            return View(nameof(DoneDeletD));
        }
        [Authorize(Roles = "Admin")]

        public IActionResult DoneDeletD()
        {

            return View("DoneDeletD");
        }
        private async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            var doctor = await _dbContext.Doctor.FindAsync(id);
            return doctor;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(doctor);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }


    }
}

