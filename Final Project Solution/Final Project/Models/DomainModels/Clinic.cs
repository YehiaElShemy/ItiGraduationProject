using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project.Models.DomainModels
{
    public class Clinic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Id { get; set; }
        public string? Email { get; set; }
        public string Name { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        [DataType(DataType.Time)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Time)]
        public DateTime? EndDate { get; set; }
        public string? PhoneClinic { get; set; }
        public List<Appointment>? Appointments { get; set; }
        public List<Clinic_patient>? Clinic_Patients { get; set; }
        public List<Doctor>? Doctors { get; set; }

    }

}
