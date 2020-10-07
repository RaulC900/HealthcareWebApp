using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthcareWebApplication.Models
{
    public class SubjectMedicationModel
    {
        [Display(Name = "Medication Id")]
        public int MedicationId { get; set; }

        [Display(Name = "Quantity")]
        [Range(1, 100)]
        [Required(ErrorMessage = "Quantity required")]
        public int Quantity { get; set; }

        [Display(Name = "Subject Id")]
        public int SubjectId { get; set; }

        [Display(Name = "Site Id")]
        public int SiteId { get; set; }
    }
}