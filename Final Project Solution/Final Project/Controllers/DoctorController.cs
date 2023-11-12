using Final_Project.Models.DataContext;
using Final_Project.Models.DomainModels;
using Final_Project.Repositary;
using Final_Project.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Final_Project.Controllers
{
    public class DoctorController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly UserRepositry userRepositry;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly DataContext db;

        public DoctorController(SignInManager<ApplicationUser> _signInManager, RoleManager<IdentityRole> roleManager,
            DataContext _db, UserManager<ApplicationUser> userManager, UserRepositry _userRepositry)
        {

            this.signInManager = _signInManager;
            this.roleManager = roleManager;
            db = _db;
            this.userManager = userManager;
            userRepositry = _userRepositry;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Detailes(string id)
        {
            var users = await userManager.GetUsersInRoleAsync("Doctor");
            var doctor = users.Where(d => d.Id == id).FirstOrDefault();

            ViewBag.specialDoctor = db.DoctroSpecialists.FirstOrDefault(d => d.DoctorId == doctor.Id).SpecialName;
            ViewBag.DoctorPhones = db.PhoneUsers.FirstOrDefault(d => d.UserId == doctor.Id).PhoneNumber;

            return View(doctor);
        }

        [HttpGet]
        public async Task<IActionResult> searchDoctor()
        {
            var users = await userManager.GetUsersInRoleAsync("Doctor");
            List<UserRegisterVM> doctors = new List<UserRegisterVM>();
            foreach (var doc in users)
            {
                doctors.Add(new UserRegisterVM()
                {
                    Id = doc.Id,
                    UserName = doc.UserName,
                    //PhoneNumber = doc.PhoneNumber,
                    Email = doc.Email,
                    SpecialistDoctors = db.DoctroSpecialists.Where(d => d.DoctorId == doc.Id).Select(d => d.SpecialName).ToList(),
                    Gender = doc.Gender,
                    Age = doc.Age,
                    City = doc.City,
                    Country = doc.Country,
                    Region = doc.Region,
                    Doctor_State = doc.Doctor_State,
                    ImageName = doc.ImageName

                });
            }
            return View(doctors);

        }

        [HttpPost]
        public IActionResult searchDoctor(string doctorName, string region, string specialname)
        {
            var searchQuery = from d in db.ApplicationUsers
                              join c in db.Clinics on d.ClinicId equals c.Id
                              join s in db.DoctroSpecialists on d.Id equals s.DoctorId
                              where d.ClinicId==c.Id && d.Id==s.DoctorId 
                              select new { d, c, s };
            var result = searchQuery.ToList();
            if (!string.IsNullOrEmpty(doctorName) || !string.IsNullOrEmpty(region) ||
                !string.IsNullOrEmpty(specialname))
            {
                searchQuery = searchQuery.Where(a => a.d.UserName.Contains(doctorName) ||
                a.c.City.Contains(region) || a.s.SpecialName.Contains(specialname));
                result = searchQuery.ToList();
            }
            List<UserRegisterVM> doctors = new List<UserRegisterVM>();
            foreach (var doc in result)
            {
                // var users = await userManager.GetUsersInRoleAsync("Doctor");
                doctors.Add(new UserRegisterVM()
                {
                    Id = doc.d.Id,
                    UserName = doc.d.UserName,
                    //PhoneNumber = doc.PhoneNumber,
                    Email = doc.d.Email,
                    SpecialistDoctors = db.DoctroSpecialists.Where(d => d.DoctorId == doc.d.Id).Select(d => d.SpecialName).ToList(),
                    Gender = doc.d.Gender,
                    Age = doc.d.Age,
                    City = doc.d.City,
                    Country = doc.d.Country,
                    Region = doc.d.Region,
                    Doctor_State = doc.d.Doctor_State,
                    ImageName = doc.d.ImageName
                });

            }

            return View("searchDoctor", doctors);

        }
    }

}
