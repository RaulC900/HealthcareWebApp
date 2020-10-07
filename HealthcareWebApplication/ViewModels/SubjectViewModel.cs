using HealthcareWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthcareWebApplication.ViewModels
{
    public class SubjectViewModel
    {
        public SubjectModel Subject { get; set; }
        public IEnumerable<SiteModel> Sites { get; set; }
        public IEnumerable<GenderModel> Genders { get; set; }
    }
}