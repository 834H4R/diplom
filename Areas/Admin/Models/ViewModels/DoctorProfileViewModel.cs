using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Areas.Admin.Models.ViewModels
{
    public class DoctorProfileViewModel
    {
        public string FullName {get; set;}
        public string Email {get; set;}
        public string PhoneNumber {get; set;}
        public string Speciality {get; set;}
        public string ImagePath {get; set;}
    }
}
