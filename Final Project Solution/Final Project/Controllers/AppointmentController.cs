using Final_Project.Models.DataContext;
using Final_Project.Models.DomainModels;
using Final_Project.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly DataContext db;

        public AppointmentController(UserManager<ApplicationUser> userManager ,DataContext _db)
        {
            this.userManager = userManager;
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
      
        public async Task<IActionResult> AddAppoint(AppointmentVm newAppoint ,string Id)
        { 
            if(ModelState.IsValid)
            {
                ApplicationUser Doctor = await userManager.FindByIdAsync(Id);
                ApplicationUser Patient = await userManager.FindByEmailAsync(newAppoint.Email);
                var clinic = db.Clinics.Find(Doctor.ClinicId);
                if (Patient == null || Doctor == null || clinic == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                Appointment appointment = new Appointment()
                {
                    PatientName = newAppoint.PatientName,
                    PhoneNumber = newAppoint.PhoneNumber,
                    DoctorId = Doctor.Id,
                    PatientId = Patient.Id,
                    Description = newAppoint.Description,
                    DateReserved = newAppoint.DateReserved,
                    TimeReserved = newAppoint.TimeReserved,
                    ClinicId = clinic.Id

                };
                db.Appointments.Add(appointment);
                db.SaveChanges();


                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "email is required");
                return RedirectToAction("searchDoctor", "Doctor");
            }

        }


    }
}
