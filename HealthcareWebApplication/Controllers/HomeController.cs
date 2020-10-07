using HealthcareWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using static DataLibrary.Logic.EmployeeProcessor;
using static DataLibrary.Logic.SiteProcessor;
using static DataLibrary.Logic.SubjectProcessor;
using static DataLibrary.Logic.GenderProcessor;
using static DataLibrary.Logic.DepotProcessor;
using static DataLibrary.Logic.SiteMedicationProcessor;
using static DataLibrary.Logic.SubjectMedicationProcessor;
using System.Security.Policy;
using HealthcareWebApplication.ViewModels;
using DataLibrary.Logic;
using System.Text;

namespace HealthcareWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SignUp()
        {
            ViewBag.Message = "SignUp Page";

            return View();
        }

        public ActionResult AddSite()
        {
            ViewBag.Message = "Add Site Page";

            return View();
        }

        public ActionResult AddSubject()
        {
            ViewBag.Message = "Add Subject Page";

            var data = LoadSites();
            List<SiteModel> sites = new List<SiteModel>();

            foreach (var row in data)
            {
                sites.Add(new SiteModel
                {
                    SiteNumber = row.SiteNumber,
                    Address = row.Address,
                    SiteDoctor = row.SiteDoctor
                });

            }

            var data1 = LoadGenders();
            List<GenderModel> genders = new List<GenderModel>();

            foreach (var row in data1)
            {
                genders.Add(new GenderModel
                {
                    Id = row.Id,
                    Gender = row.Gender
                });

            }

            var viewModel = new SubjectViewModel()
            {
                Subject = new SubjectModel(),
                Sites = sites,
                Genders = genders
            };

           
            return View(viewModel);
        }

        public ActionResult AddMedicationToDepot()
        {
            ViewBag.Message = "Add Medication To Depot";

            return View();
        }

        public ActionResult ViewSites()
        {
            ViewBag.Message = "Sites List";

            var data = LoadSites();
            List<SiteModel> sites = new List<SiteModel>();

            foreach (var row in data)
            {
                bool listContainsMedication = false;
                var data1 = LoadSiteMedication(row.SiteNumber);
                string medicationListString = "";
                var medStringBuilder = new StringBuilder(medicationListString);
                foreach (var row1 in data1)
                {
                    if (row1.Quantity > 0)
                    {
                        medStringBuilder.Append(row1.Quantity + " x " + row1.MedicationId + ", ");
                        listContainsMedication = true;
                    }
                }
                if (listContainsMedication == true)
                {
                    medStringBuilder.Remove(medStringBuilder.Length - 3, 2);
                }
                medicationListString = medStringBuilder.ToString();

                sites.Add(new SiteModel
                {
                    SiteNumber = row.SiteNumber,
                    Address = row.Address,
                    SiteDoctor = row.SiteDoctor,
                    MedicationUnits = medicationListString
                });

            }

            return View(sites);
        }

        public ActionResult ViewSubjects()
        {
            ViewBag.Message = "Subjects List";

            var data = LoadSubjects();
            var subjects = new List<SubjectModel>();

            foreach (var row in data)
            {
                bool listContainsMedication = false;
                var data1 = LoadSubjectMedication(row.SubjectNumber);
                string medicationListString = "";
                var medStringBuilder = new StringBuilder(medicationListString);
                foreach (var row1 in data1)
                {
                    if(row1.Quantity > 0)
                    {
                        medStringBuilder.Append(row1.Quantity + " x " + row1.MedicationId + ", ");
                        listContainsMedication = true;
                    }
                }
                if(listContainsMedication == true)
                {
                    medStringBuilder.Remove(medStringBuilder.Length - 3, 2);
                }
                medicationListString = medStringBuilder.ToString();

                subjects.Add(new SubjectModel
                {
                    SubjectNumber = row.SubjectNumber,
                    Gender = row.Gender,
                    DateOfBirth = row.DateOfBirth,
                    SiteNumber = row.SiteNumber,
                    MedicationUnits = medicationListString
                });

            }

            return View(subjects);
        }

        public ActionResult ViewEmployees()
        {
            ViewBag.Message = "Employees List";

            var data = LoadEmployees();
            List<EmployeeModel> employees = new List<EmployeeModel>();

            foreach (var row in data)
            {
                employees.Add(new EmployeeModel
                {
                    EmployeeId = row.EmployeeId,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    EmailAddress = row.EmailAddress
                });

            }

            return View(employees);
        }

        public ActionResult ViewDepot()
        {
            ViewBag.Message = "Depot Inventory";

            var data = LoadDepot();
            List<DepotModel> depot = new List<DepotModel>();

            foreach (var row in data)
            {
                depot.Add(new DepotModel
                {
                    MedicationId = row.MedicationId,
                    Quantity = row.Quantity
                });

            }

            return View(depot);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateEmployee(model.FirstName, model.LastName, model.EmailAddress);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSite(SiteModel model)
        {
            if (ModelState.IsValid)
            {
                var data = LoadSites();
                List<SiteModel> sites = new List<SiteModel>();
                foreach (var row in data)
                {
                    sites.Add(new SiteModel
                    {
                        SiteNumber = row.SiteNumber,
                        Address = row.Address,
                        SiteDoctor = row.SiteDoctor
                    });
                }
                bool exists = false;
                foreach(var site in sites)
                {
                    if(site.SiteNumber == model.SiteNumber)
                    {
                        exists = true;
                        break;
                    }
                }
                if(exists == false)
                {
                    int recordsCreated = CreateSite(model.SiteNumber, model.Address, model.SiteDoctor);
                    return RedirectToAction("ViewSites");
                }
                else
                {
                    model.SiteNumber = model.SiteNumber + 1;
                    AddSite(model);
                    return RedirectToAction("ViewSites");
                }
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSubject(SubjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateSubject(model.Subject.Gender, model.Subject.DateOfBirth, model.Subject.SiteNumber);
                return RedirectToAction("ViewSubjects");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMedicationToDepot(DepotModel model)
        {
            if (ModelState.IsValid)
            {
                var data = LoadDepot();
                List<DepotModel> depot = new List<DepotModel>();
                foreach (var row in data)
                {
                    depot.Add(new DepotModel
                    {
                        MedicationId = row.MedicationId,
                        Quantity = row.Quantity
                    });
                }
                bool exists = false;
                foreach (var medication in depot)
                {
                    if (medication.MedicationId == model.MedicationId)
                    {
                        AddMedicationQuantity(model.MedicationId, model.Quantity);
                        exists = true;
                        break;
                    }
                }
                if (exists == false)
                {
                    int recordsCreated = AddToDepot(model.MedicationId, model.Quantity);
                    return RedirectToAction("ViewDepot");
                }
                return RedirectToAction("ViewDepot");
            }
            else
            {
                return View();
            }
        }

        public ActionResult OrderMedicationForSites(int id)
        {
            ViewBag.Message = "Order Medication For Sites Page";


            var data = LoadDepot();
            List<DepotModel> medication = new List<DepotModel>();

            foreach (var row in data)
            {
                medication.Add(new DepotModel
                {
                    MedicationId = row.MedicationId,
                    Quantity = row.Quantity
                });

            }

            //var data1 = LoadSites();
            //List<SiteModel> sites = new List<SiteModel>();

            //foreach (var row in data1)
            //{
            //    sites.Add(new SiteModel
            //    {
            //        SiteNumber = row.SiteNumber,
            //        Address = row.Address,
            //        SiteDoctor = row.SiteDoctor
            //    });
            //}

            var viewModel = new OrderSiteMedicationViewModel()
            {
                SiteMedication = new SiteMedicationModel
                {
                    MedicationId = 0,
                    Quantity = 0,
                    SiteId = id
                },
                Medication = medication
            };

            return View(viewModel);
        }

        public ActionResult OrderMedicationForSubjects(int id, int role)
        {
            ViewBag.Message = "Order Medication For Subjects Page";

            var data = LoadSubjects();
            List<SubjectModel> subjects = new List<SubjectModel>();

            foreach (var row in data)
            {
                subjects.Add(new SubjectModel
                {
                    SubjectNumber = row.SubjectNumber,
                    SiteNumber = row.SiteNumber
                });

            }

            bool siteIsActive = false;
            var activeSites = LoadSites();
            foreach (var row in activeSites)
            {
                if(row.SiteNumber == role)
                {
                    siteIsActive = true;
                    break;
                }
            }

            if(siteIsActive == true)
            {
                var data1 = LoadSiteMedication(role);
                List<DepotModel> medication = new List<DepotModel>();

                foreach (var row in data1)
                {
                    if (row.Quantity > 0)
                    {
                        medication.Add(new DepotModel
                        {
                            MedicationId = row.MedicationId,
                            Quantity = row.Quantity
                        });
                    }
                }

                var viewModel = new OrderSubjectMedicationViewModel()
                {
                    SubjectMedication = new SubjectMedicationModel
                    {
                        MedicationId = 0,
                        Quantity = 0,
                        SubjectId = id,
                        SiteId = role
                    },
                    Medication = medication,
                };

                return View(viewModel);

            }
            else
            {
                //error site inactive
                ViewBag.Error = "Site Inactive";
                return RedirectToAction("ViewSubjects");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OrderMedicationForSites(OrderSiteMedicationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var data = LoadSiteMedication(model.SiteMedication.SiteId);
                List<SiteMedicationModel> medication = new List<SiteMedicationModel>();
                foreach (var row in data)
                {
                    medication.Add(new SiteMedicationModel
                    {
                        MedicationId = row.MedicationId,
                        Quantity = row.Quantity,
                        SiteId = row.SiteId
                    });
                }
                bool exists = false;
                foreach (var med in medication)
                {
                    if (med.MedicationId == model.SiteMedication.MedicationId)
                    {
                        var data1 = LoadDepotMedication(model.SiteMedication.MedicationId);
                        foreach (var row in data1)
                        {
                            if (row.MedicationId == model.SiteMedication.MedicationId)
                            {
                                if (model.SiteMedication.Quantity <= row.Quantity)
                                {
                                    UpdateSiteMedicationQuantity(model.SiteMedication.MedicationId, model.SiteMedication.Quantity, model.SiteMedication.SiteId);
                                    DecreaseMedicationQuantity(model.SiteMedication.MedicationId, model.SiteMedication.Quantity);
                                }
                                else
                                {
                                    ViewBag.Error = "Not enough medication in inventory";
                                    return RedirectToAction("ViewSites");
                                    //error not enough medication in inventory
                                }
                                break;
                            }
                        }
                        exists = true;
                        break;
                    }
                }
                if (exists == false)
                {
                    var data1 = LoadDepotMedication(model.SiteMedication.MedicationId);
                    foreach (var row in data1)
                    {
                        if (row.MedicationId == model.SiteMedication.MedicationId)
                        {
                            if (model.SiteMedication.Quantity <= row.Quantity)
                            {
                                DecreaseMedicationQuantity(model.SiteMedication.MedicationId, model.SiteMedication.Quantity);
                                int recordsCreated = AddSiteMedication(model.SiteMedication.MedicationId, model.SiteMedication.Quantity, model.SiteMedication.SiteId);
                                return RedirectToAction("ViewSites");
                            }
                            else
                            {
                                ViewBag.Error = "Not enough medication in inventory";
                                return RedirectToAction("ViewSites");
                                //error not enough medication in inventory
                            }
                        }
                    }
                    return RedirectToAction("ViewSites");
                }
                return RedirectToAction("ViewSites");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OrderMedicationForSubjects(OrderSubjectMedicationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var data = LoadSubjectMedication(model.SubjectMedication.SubjectId);
                List<SubjectMedicationModel> medication = new List<SubjectMedicationModel>();
                foreach (var row in data)
                {
                    medication.Add(new SubjectMedicationModel
                    {
                        MedicationId = row.MedicationId,
                        Quantity = row.Quantity,
                        SubjectId = row.SubjectId
                    });
                }
                bool exists = false;
                foreach (var med in medication)
                {
                    if (med.MedicationId == model.SubjectMedication.MedicationId)
                    {
                        var data1 = LoadSiteMedication(model.SubjectMedication.SiteId);
                        foreach(var row in data1)
                        {
                            if(row.MedicationId == model.SubjectMedication.MedicationId)
                            {
                                if(model.SubjectMedication.Quantity <= row.Quantity)
                                {
                                    UpdateSubjectMedicationQuantity(model.SubjectMedication.MedicationId, model.SubjectMedication.Quantity, model.SubjectMedication.SubjectId);
                                    DecreaseSiteMedicationQuantity(model.SubjectMedication.MedicationId, model.SubjectMedication.Quantity, model.SubjectMedication.SiteId);
                                }
                                else
                                {
                                    //error not enough medication in inventory
                                }
                                exists = true;
                                break;
                            }
                        }
                        exists = true;
                        break;
                    }
                }
                if (exists == false)
                {
                    var data1 = LoadSiteMedication(model.SubjectMedication.SiteId);
                    foreach (var row in data1)
                    {
                        if (row.MedicationId == model.SubjectMedication.MedicationId)
                        {
                            if (model.SubjectMedication.Quantity <= row.Quantity)
                            {
                                DecreaseSiteMedicationQuantity(model.SubjectMedication.MedicationId, model.SubjectMedication.Quantity, model.SubjectMedication.SiteId);
                                int recordsCreated = AddSubjectMedication(model.SubjectMedication.MedicationId, model.SubjectMedication.Quantity, model.SubjectMedication.SubjectId, model.SubjectMedication.SiteId);
                            }
                            else
                            {
                                //error not enough medication in inventory
                            }
                            exists = true;
                            break;
                        }
                    }
                    return RedirectToAction("ViewSubjects");
                }
                return RedirectToAction("ViewSubjects");
            }
            else
            {
                return View();
            }
        }

        public ActionResult EditSite(int param1, string param2, string param3)
        {
            ViewBag.Message = "Edit Site Page";

            var site = new SiteModel
            {
                SiteNumber = param1,
                Address = param2,
                SiteDoctor = param3
            };

            return View(site);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSite(SiteModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = UpdateSite(model.SiteNumber, model.Address, model.SiteDoctor);
                return RedirectToAction("ViewSites");
            }
            else
            {
                return View();
            }
        }

        public ActionResult DeleteSite(int param1)
        {
            DeleteSiteFromTable(param1);
            return RedirectToAction("ViewSites");
        }

        public ActionResult EditSubject(int param1, string param2, DateTime param3, int param4)
        {
            ViewBag.Message = "Edit Subject Page";

            var data = LoadSites();
            List<SiteModel> sites = new List<SiteModel>();

            foreach (var row in data)
            {
                sites.Add(new SiteModel
                {
                    SiteNumber = row.SiteNumber,
                    Address = row.Address,
                    SiteDoctor = row.SiteDoctor
                });

            }

            var data1 = LoadGenders();
            List<GenderModel> genders = new List<GenderModel>();

            foreach (var row in data1)
            {
                genders.Add(new GenderModel
                {
                    Id = row.Id,
                    Gender = row.Gender
                });
            }

            var viewModel = new SubjectViewModel()
            {
                Subject = new SubjectModel
                {
                    SubjectNumber = param1,
                    Gender = param2,
                    DateOfBirth = param3,
                    SiteNumber = param4

                },
                Sites = sites,
                Genders = genders
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSubject(SubjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = UpdateSubject(model.Subject.SubjectNumber, model.Subject.Gender, model.Subject.DateOfBirth, model.Subject.SiteNumber);
                return RedirectToAction("ViewSubjects");
            }
            else
            {
                return View();
            }
        }

        public ActionResult DeleteSubject(int param1)
        {
            DeleteSubjectFromTable(param1);
            return RedirectToAction("ViewSubjects");
        }

        public ActionResult EditDepotMedication(int param1, int param2)
        {
            ViewBag.Message = "Edit Depot Medication Page";

            var depotMed = new DepotModel
            {
                MedicationId = param1,
                Quantity = param2
            };

            return View(depotMed);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDepotMedication(DepotModel model)
        {
            EditMedQuantity(model.MedicationId, model.Quantity);
            return RedirectToAction("ViewDepot");
        }

        public ActionResult DeleteDepotMedication(int param1)
        {
            DeleteDepotMed(param1);
            return RedirectToAction("ViewDepot");
        }

    }
}