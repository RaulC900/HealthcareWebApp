using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthcareWebApplication.Models
{
    public class SiteModel
    {
        [Display(Name = "Site Number")]
        [Required]
        [RegularExpression("^[0-9]{5}$", ErrorMessage = "Site Number must have 5 digits")]
        public int SiteNumber { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address required")]
        public string Address { get; set; }

        [Display(Name = "Site Doctor")]
        [Required(ErrorMessage = "Site Doctor required")]
        public string SiteDoctor { get; set; }

        [Display(Name = "Medication Units")]
        public string MedicationUnits { get; set; }
    }
}