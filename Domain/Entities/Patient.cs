using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class Patient
    {
        public Patient()
        {
            DateAdded = DateTime.Now.ToUniversalTime();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Прізвище, ім'я, по-батькові")]
        public virtual string Name { get; set; }

        [Display(Name = "Дата народження")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Номер телефону")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Фото")]
        public virtual string ImgPath { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }

        public virtual List<Document> Documents {get;set;}

    }
}
