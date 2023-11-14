using Final_Project.Models.DataContext;
using Final_Project.Models.DomainModels;
using Final_Project.Repositary;
using Final_Project.ViewModel;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using static Azure.Core.HttpHeader;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

            ViewBag.specialDoctor = db.DoctorSpecialists.FirstOrDefault(d => d.DoctorId == doctor.Id).SpecialName;
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
                    SpecialistDoctors = db.DoctorSpecialists.Where(d => d.DoctorId == doc.Id).Select(d => d.SpecialName).ToList(),
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
        public IActionResult searchDoctor(string doctorName, string region, string specialName)
        {
            // Start with a base query that includes the necessary navigation properties
            var searchQuery = db.Users.Where(d=>d.DoctorSpecialists.Count()!=0).Include(d => d.DoctorSpecialists).Include(user => user.Clinic).ToList();

            // Apply filters based on the provided parameters
            if (!string.IsNullOrEmpty(doctorName))
            {
                searchQuery = searchQuery.Where(u => u.UserName.Contains(doctorName)).ToList();
            }

            if (!string.IsNullOrEmpty(region))
            {
                searchQuery = searchQuery.Where(u => u.Clinic.City.Contains(region)).ToList();
            }

            if (!string.IsNullOrEmpty(specialName))
            {
                searchQuery = searchQuery.Where(u => u.DoctorSpecialists.Any(ds => ds.SpecialName.Contains(specialName))).ToList();
            }

            // Execute the query and retrieve the results
            var searchResults = searchQuery.ToList();

            // You can now use the searchResults as needed, for example, pass it to a view

            List<UserRegisterVM> doctors = new List<UserRegisterVM>();
            foreach (var doc in searchResults)
            {
                // var users = await userManager.GetUsersInRoleAsync("Doctor");
                doctors.Add(new UserRegisterVM()
                {
                    Id = doc.Id,
                    UserName = doc.UserName,
                    //PhoneNumber = doc.PhoneNumber,
                    Email = doc.Email,
                    SpecialistDoctors = db.DoctorSpecialists.Where(d => d.DoctorId == doc.Id).Select(d => d.SpecialName).ToList(),
                    Gender = doc.Gender,
                    Age = doc.Age,
                    City = doc.City,
                    Country = doc.Country,
                    Region = doc.Region,
                    Doctor_State = doc.Doctor_State,
                    ImageName = doc.ImageName
                });

            }

            return View("searchDoctor", doctors);


        }

      


    }

}
