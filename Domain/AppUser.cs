using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
    public class AppUser : IdentityUser
    {
        [PersonalData]
        public string Login { get; set; }

        public string Speciality { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string ImgPath { get; set; }

        public virtual List<Document> Documents {get; set; }

    }
}
