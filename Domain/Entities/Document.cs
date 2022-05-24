using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
    public class Document
    {
        public Document()
        {
            ExtraditionDate = DateTime.Now.ToUniversalTime();
        }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string ImagePath {get;set;}

        [Required]
        [Display(Name ="Тип справки")]
        public string DocumentType { get; set; }

        [Display(Name = "Ким надана")]
        [ForeignKey("AppUserId")]
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        [Display(Name = "Кому надана")]
        [ForeignKey("PatientId")]
        public Guid PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        [Display(Name = "Дата видачі")]
        [DataType(DataType.Date)]
        public DateTime ExtraditionDate;

    }
}
