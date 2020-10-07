using HealthcareWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthcareWebApplication.ViewModels
{
    public class OrderSubjectMedicationViewModel
    {
        public SubjectMedicationModel SubjectMedication { get; set; }
        public IEnumerable<DepotModel> Medication { get; set; }
        public IEnumerable<SubjectModel> Subjects { get; set; }
    }
}