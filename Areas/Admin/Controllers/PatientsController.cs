using App.Domain;
using App.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PatientsController : Controller
    {

        private readonly DataManager _dataManager;
        public PatientsController(DataManager dataManager)
        {
            this._dataManager = dataManager;
        }

        public IActionResult Index()
        {
           return View(_dataManager.Patients.GetPatients());
        }

        public IActionResult Edit(Guid Id)
        {
            var Patient = _dataManager.Patients.GetPatientById(Id);
            return View(Patient);
        }
        [HttpPost]
        public IActionResult Edit(Patient model)
        {
            if(ModelState.IsValid)
            {
                _dataManager.Patients.SavePatient(model);
            }
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Patient model)
        {
            if(ModelState.IsValid)
            {
                Patient NewPatient = new Patient{Name = model.Name, BirthDate = model.BirthDate, PhoneNumber = model.PhoneNumber,
                ImgPath = model.ImgPath};
            _dataManager.Patients.SavePatient(NewPatient);
                return RedirectToAction("Index","Patients");
            }
            return View(model);            
        }

    }
}
