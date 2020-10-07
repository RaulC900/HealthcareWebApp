using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthcareWebApplication.Models
{
    public class SubjectModel
    {
        [Display(Name = "Subject Number")]
        public int SubjectNumber { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender required")]
        public string Gender { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date of birth required")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Site Number")]
        [Required(ErrorMessage = "Site Number Required")]
        public int SiteNumber { get; set; }

        [Display(Name = "Medication Units")]
        public string MedicationUnits { get; set; }
    }
}