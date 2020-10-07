using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace HealthcareWebApplication.Models
{
    public class DepotModel
    {
        [Display(Name = "Medication Id")]
        [Required(ErrorMessage = "Medication Id required")]
        [RegularExpression("^[0-9]{6}$", ErrorMessage = "Medication Id must have 6 digits")]
        public int MedicationId { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}