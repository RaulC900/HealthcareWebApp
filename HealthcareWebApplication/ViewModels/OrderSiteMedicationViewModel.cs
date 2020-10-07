using HealthcareWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthcareWebApplication.ViewModels
{
    public class OrderSiteMedicationViewModel
    {
        public SiteMedicationModel SiteMedication { get; set; }
        public IEnumerable<DepotModel> Medication { get; set; }
        public IEnumerable<SiteModel> Sites { get; set; }
    }
}