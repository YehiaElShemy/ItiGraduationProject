using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Final_Project.ViewModel
{
    public class UserRegisterVM
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        [Required]
        [EmailAddress]
        [Remote("IsEmailAvailable", "Account", ErrorMessage = "The email address is already in use.")]
        public string Email { get; set; }
        public List<string>? PhoneNumbers { get; set; }
        [Required(ErrorMessage ="Enter Your Age")]
        public int? Age { get; set; }
        [Required(ErrorMessage ="Gender Required")]
        public string? Gender { get; set; }
        public string? ClinicId { get; set; }
        [Required(ErrorMessage ="Image Required" )]
        //[DataType(DataType.Upload)]
        [RegularExpression(@"^.*\.(jpg|jpeg|png|gif)$", ErrorMessage = "Only jpg, jpeg, png, and gif file types are allowed.")]
        public IFormFile Image { get; set; }
        public string? ImageName { get; set; }
        [Required(ErrorMessage = "Enter Your Country")]
        public string? Country { get; set; }
        [Required(ErrorMessage = "Enter Your City")]

        public string? City { get; set; }
        [Required(ErrorMessage ="Enter Your Regoin")]
        public string? Region { get; set; }
        public List<string>? SpecialistDoctors { get; set; }
        [DataType(DataType.Password), Required(ErrorMessage = "Enter complex password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password Not Matched with Confirm Password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Enter Your Role")]
        public string RoleName { get; set; }
    }
}
