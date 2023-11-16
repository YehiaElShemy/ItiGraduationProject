using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project.Models.DomainModels
{
    public class Clinic_patient
    {
        [Key]
        [StringLength(100)] // Assuming you are using GUIDs
        public string Id { get; set; }
        public string Clinic_Message { get; set; }
        public DateTime Date_Messge { get; set; }
        [ForeignKey(nameof(Clinic))]
        public string CinicId { get; set; }
        public Clinic Clinic { get; set; }
        [ForeignKey(nameof(Patient))]
        public string PatientId { get; set; }
        public Patient Patient { get; set; }

    }

}
