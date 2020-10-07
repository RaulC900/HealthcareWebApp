using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthcareWebApplication.Models
{
    public class SiteMedicationModel
    {
        [Display(Name = "Medication Id")]
        public int MedicationId { get; set; }

        [Display(Name = "Quantity")]
        [Range(1, 100)]
        [Required(ErrorMessage = "Quantity required")]
        public int Quantity { get; set; }

        [Display(Name = "Site Id")]
        public int SiteId { get; set; }
    }
}