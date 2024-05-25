using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhongKhamOnline.DataAccess;
using PhongKhamOnline.Models;
using System.Security.Claims;

namespace PhongKhamOnline.Areas.User.Controllers
{
    [Area("User")]
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Appointment> appointments;

            if (User.IsInRole("admin") || User.IsInRole("customer"))
            {
                appointments = _context.Appointments.Include(a => a.BacSi).ToList();
            }
            else
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                appointments = _context.Appointments.Include(a => a.BacSi).Where(a => a.UserId == userId).ToList();
            }

            return View(appointments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.BacSis = new SelectList(_context.BacSis, "Id", "Ten");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            if (ModelState.IsValid != null)
            {
                appointment.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Lấy UserID của người dùng hiện tại
                _context.Appointments.Add(appointment);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Đặt lịch thành công!";
                return RedirectToAction("Index");
            }

            ViewBag.BacSis = new SelectList(_context.BacSis, "Id", "Ten");
            return View(appointment);
        }


        [HttpPost]
        public IActionResult Confirm(int id)
        {
            var appointment = _context.Appointments.Find(id);
            if (appointment != null && appointment.Status == AppointmentStatus.Pending)
            {
                appointment.Status = AppointmentStatus.Confirmed;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Cancel(int id)
        {
            var appointment = _context.Appointments.Find(id);
            if (appointment != null && appointment.Status == AppointmentStatus.Pending)
            {
                appointment.Status = AppointmentStatus.Cancelled;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }

}
