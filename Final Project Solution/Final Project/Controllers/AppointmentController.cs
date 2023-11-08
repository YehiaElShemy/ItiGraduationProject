using Final_Project.Models.DataContext;
using Final_Project.Models.DomainModels;
using Final_Project.ViewModel;
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
            
            ApplicationUser Doctor = await userManager.FindByIdAsync(Id);
            ApplicationUser Patient = await userManager.FindByEmailAsync(newAppoint.Email);
            var clinic=db.Clinics.Find(Doctor.Id);
            if (Patient == null || Doctor==null || clinic==null)
            {
                return View("Detailes", "Doctor");
            }
            Appointment appointment = new Appointment()
            {
                PatientName=newAppoint.PatientName,
                PhoneNumber=newAppoint.PhoneNumber,
                DoctorId=Doctor.Id,
                PatientId=Patient.Id,
                Description=newAppoint.Description,
                DateReserved =newAppoint.DateReserved,
                TimeReserved=newAppoint.TimeReserved,
                ClinicId="122"//clinic.Id
                
            };
            db.Appointments.Add(appointment);
            db.SaveChanges();


            return View("Index","Home");
        }
    }
}
