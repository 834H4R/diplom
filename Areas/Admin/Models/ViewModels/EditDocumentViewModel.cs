using App.Domain;
using App.Domain.Entities;
using System;
using System.Collections.Generic;


namespace App.Areas.Admin.Models.ViewModels
{
    public class EditDocumentViewModel
    {
        public IEnumerable<AppUser> Users{get;set;}
        public IEnumerable<Patient> Patietns{get;set;}
        public Document Document {get;set;}
    }
}
